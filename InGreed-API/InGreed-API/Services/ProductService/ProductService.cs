using InGreed_API.DataContext;
using InGreed_API.Dtos;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses.ProductResponse;
using InGreed_API.Dtos.Results;
using InGreed_API.Models;
using InGreed_API.QueryBuilder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InGreed_API.Services.ProductService
{
    public class ProductService(InGreedDataContext inGreedDataContext) : IProductService
    {
        public async Task<ResultBase> AddFavouriteProduct(FavouriteProductRequest fpr)
        {
            var favouriteProduct = inGreedDataContext.FavouriteProducts
                .FirstOrDefault(fp => fp.UserId == fpr.UserId && fp.ProductId == fpr.ProductId);

            if (favouriteProduct != null)
                return new ResultBase(false, "Favourite product already exists");

            favouriteProduct = new FavouriteProduct()
            {
                UserId = fpr.UserId,
                ProductId = fpr.ProductId,
            };

            await inGreedDataContext.FavouriteProducts.AddAsync(favouriteProduct);
            await inGreedDataContext.SaveChangesAsync();

            return new ResultBase(true);
        }

        public async Task<ResultBase> DeleteFavouriteProduct(FavouriteProductRequest fpr)
        {
            var favouriteProduct = await inGreedDataContext.FavouriteProducts
                .FirstOrDefaultAsync(fp => fp.UserId == fpr.UserId && fp.ProductId == fpr.ProductId);

            if (favouriteProduct != null)
            {
                inGreedDataContext.FavouriteProducts.Remove(favouriteProduct);
                await inGreedDataContext.SaveChangesAsync();

                return new ResultBase(true);
            }

            return new ResultBase(false, "Favourite product doesn't exist");
        }

        private QueryBuilder<Product> PrepateProductQueryBase(ProductRequest productRequest, Person person)
        {
            var queryBuilder = new QueryBuilder<Product>(
                inGreedDataContext.Products
                .Include(p => p.ProductCategory)
                .ThenInclude(pc => pc.Category)
                .Include(p => p.Promotion)
                .Include(p => p.ProductIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .ThenInclude(i => i.Preferenes)
                .Include(p => p.Opinions)
                .Include(p => p.FavouriteProducts)
                );

            if (productRequest.SearchPhrase != null && productRequest.SearchPhrase != "")
                queryBuilder.Filter(p => p.Name.ToLower().Contains(productRequest.SearchPhrase.ToLower()));
            if (productRequest.Category != null && productRequest.Category != 0)
                queryBuilder.Filter(p => p.ProductCategory.Any(pc => pc.Category.Id == productRequest.Category));
            if (productRequest.Ingredients != null)
                queryBuilder.Filter(p => productRequest.Ingredients.All(i => p.ProductIngredients.Any(pi => pi.Ingredient.Id == i)));
            if (person != null)
            {
                switch (person.Role)
                {
                    case Enums.UserRoleEnum.Client:
                        queryBuilder.Filter(p => p.ProductIngredients.All(pi => pi.Ingredient.Preferenes.All(p => p.UserId != person.Id || p.PreferenceType != Enums.PreferenceEnum.Allergen)));
                        if (productRequest.OnlyFavourite)
                            queryBuilder.Filter(p => p.FavouriteProducts.Any(fp => fp.UserId == productRequest.Id));
                        break;
                    case Enums.UserRoleEnum.Producent:
                        queryBuilder.Filter(p => p.ProducentId == person.Id);
                        break;
                }
            }

            return queryBuilder;
        }

        public async Task<ProductResponse> GetProducts(ProductRequest productRequest, Person person)
        {
            int? userId = null;

            if (person != null && person.Role == Enums.UserRoleEnum.Client)
                userId = person.Id;

            var promotionQueryBuilder = PrepateProductQueryBase(productRequest, person);

            promotionQueryBuilder.Filter(p => p.Promotion != null && p.Promotion.Start <= DateTime.Now && p.Promotion.End > DateTime.Now);
            promotionQueryBuilder.Sort(p => Guid.NewGuid(), true);
            promotionQueryBuilder.Paginate(productRequest.PromotionNumber, 1);

            var promotionQuery = promotionQueryBuilder.BuildWithSelect(p => new ProductRow(p, true, userId));

            var normalQueryBuilder = PrepateProductQueryBase(productRequest, person);

            int pageCount = (int)Math.Ceiling(await normalQueryBuilder.Build().CountAsync() / (double)productRequest.NormalNumber);

            normalQueryBuilder.Paginate(productRequest.NormalNumber, productRequest.PageNumber);

            var normalQuery = normalQueryBuilder.BuildWithSelect(p => new ProductRow(p, false, userId));
            
            var productRows = promotionQuery.AsEnumerable().Concat(normalQuery);

            return new ProductResponse() { ProductRows = productRows.ToList() ?? new List<ProductRow>(), NumberOfPages = pageCount };
        }

        public async Task<byte[]> GetImageForProduct(int productId)
        {
            var image = await inGreedDataContext.ProductImages.Where(p => p.Id == productId).Select(p => p.Image).SingleAsync();
            return image;
        }

        public async Task AddProduct(ProductAddRequest productRequest)
        {
            using (var transaction = await inGreedDataContext.Database.BeginTransactionAsync())
            {
                Product product = new Product()
                {
                    ProducentId = productRequest.ProducentID,
                    Description = productRequest.Description,
                    Name = productRequest.ProductName,
                };

                var p = await inGreedDataContext.Products.AddAsync(product);

                await inGreedDataContext.SaveChangesAsync();

                int productId = product.Id;

                if (productRequest.Image != null && productRequest.Image.Length > 0)
                {
                    var ms = new MemoryStream();
                    productRequest.Image.CopyTo(ms);
                    var fileBytes = ms.ToArray();

                    var productImage = new ProductImage()
                    {
                        ProductId = productId,
                        Image = fileBytes
                    };

                    await inGreedDataContext.ProductImages.AddAsync(productImage);
                    await inGreedDataContext.SaveChangesAsync();
                }

                await AddCategoriesToProduct(productId, productRequest.Category);

                await AddIngredientsToProduct(productId, productRequest.Ingredients);

                await transaction.CommitAsync();
            }
        }

        public async Task AddCategoriesToProduct(int ProductID, int Category)
        {
            var pc = new ProductCategory()
            {
                ProductId = ProductID,
                CategoryId = Category
            };

            await inGreedDataContext.ProductCategories.AddAsync(pc);
            await inGreedDataContext.SaveChangesAsync();
        }

        public async Task AddIngredientsToProduct(int ProductID, List<int> Ingredients)
        {
            if (Ingredients == null || Ingredients.Count == 0)
                return;

            var list = new List<ProductIngredient>(Ingredients.Count);
            foreach (var id in Ingredients)
            {
                list.Add(new ProductIngredient()
                {
                    ProductId = ProductID,
                    IngredientId = id,
                });
            }

            await inGreedDataContext.ProductIngredients.AddRangeAsync(list);
            await inGreedDataContext.SaveChangesAsync();
        }
    }
}

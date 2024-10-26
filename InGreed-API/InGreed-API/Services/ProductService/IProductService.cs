using InGreed_API.Dtos;
using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses.ProductResponse;
using InGreed_API.Dtos.Results;

namespace InGreed_API.Services.ProductService
{
    public interface IProductService
    {
        Task<ResultBase> AddFavouriteProduct(FavouriteProductRequest fpr);
        Task<ResultBase> DeleteFavouriteProduct(FavouriteProductRequest fpr);
        Task<ProductResponse> GetProducts(ProductRequest productRequest,Person person);
        Task<byte[]> GetImageForProduct(int productId);
        Task AddProduct(ProductAddRequest productRequest);
        Task AddCategoriesToProduct(int ProductID, int Category);
        Task AddIngredientsToProduct(int ProductID, List<int> Ingredients);

    }
}

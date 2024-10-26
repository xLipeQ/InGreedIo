using InGreed_API.DataContext;
using InGreed_API.Dtos.Responses;
using InGreed_API.Factories;
using InGreed_API.Services.CacheService.cs;
using Microsoft.EntityFrameworkCore;

namespace InGreed_API.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public static int MaxCategoriesCount = 100;
        private InGreedDataContext inGreedDataContext;
        private ICacheService cacheService;

        public CategoryService(InGreedDataContext _inGreedDataContext, IConfiguration configuration)
        {
            inGreedDataContext = _inGreedDataContext;
            cacheService = CacheServiceFactory.GetFactory(configuration);
        }

        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            string key = $"categories_empty_{MaxCategoriesCount}";
            var data = await cacheService.GetData<List<CategoryResponse>>(key);

            if (data == null)
            {
                data = await inGreedDataContext.Categories
                    .OrderBy(c => c.Type)
                    .Select(c => new CategoryResponse { Id = c.Id, Name = c.Type })
                    .Take(MaxCategoriesCount)
                    .ToListAsync();

                await cacheService.SetData(key, data);
            }

            return data;
        }

        public async Task<List<CategoryResponse>> GetAllMatchingCategories(string pattern)
        {
            string key = $"categories_{pattern}_{MaxCategoriesCount}";
            var data = await cacheService.GetData<List<CategoryResponse>>(key);

            if (data == null)
            {
                data = await inGreedDataContext.Categories
                    .Where(c => c.Type.ToLower().StartsWith(pattern.ToLower()))
                    .OrderBy(c => c.Type)
                    .Select(c => new CategoryResponse { Id = c.Id, Name = c.Type })
                    .Take(MaxCategoriesCount)
                    .ToListAsync();

                await cacheService.SetData(key, data);
            }

            return data;
        }
    }
}

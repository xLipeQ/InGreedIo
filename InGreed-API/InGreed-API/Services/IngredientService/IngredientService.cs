using InGreed_API.DataContext;
using InGreed_API.Dtos.Responses;
using InGreed_API.Dtos.Results;
using InGreed_API.Factories;
using InGreed_API.Models;
using InGreed_API.Services.AuthService;
using InGreed_API.Services.CacheService.cs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Linq;

namespace InGreed_API.Services.Ingredients
{
    public class IngredientService : IIngredientService
    {
        public static int MaxCategoriesCount = 100;
        private InGreedDataContext inGreedDataContext;
        private ICacheService cacheService;

        public IngredientService(InGreedDataContext _inGreedDataContext, IConfiguration configuration)
        {
            inGreedDataContext = _inGreedDataContext;
            cacheService = CacheServiceFactory.GetFactory(configuration);
        }

        public async Task<List<IngredientResponse>> GetAllIngredients()
        {
            string key = $"ingredients_empty_{MaxCategoriesCount}";
            var data = await cacheService.GetData<List<IngredientResponse>>(key);

            if (data == null)
            {
                data = await inGreedDataContext.Ingredients
                    .OrderBy(i => i.Name)
                    .Select(i => new IngredientResponse { Id = i.Id, Name = i.Name })
                    .Take(MaxCategoriesCount)
                    .ToListAsync();

                await cacheService.SetData(key, data);
            }

            return data;
        }
        public async Task<List<IngredientResponse>> GetProductIngredients(int productId)
        {
            //var data = await cacheService.GetData<List<IngredientResponse>>(key);

            //if (data == null)
            //{
            var data = (await inGreedDataContext.Products
                .Include(p => p.ProductIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .SingleAsync(p => p.Id == productId))
                .ProductIngredients.Select(pi => new IngredientResponse { Id = pi.Ingredient.Id, Name = pi.Ingredient.Name })
                .ToList();

            return data;

        }

        public async Task<List<IngredientResponse>> GetAllIngredients(int clientId)
        {
            var data = await inGreedDataContext.Ingredients
                    .Include(i => i.Preferenes)
                    .Where(i => i.Preferenes.All(p => p.UserId != clientId || p.PreferenceType != Enums.PreferenceEnum.Allergen))
                    .OrderBy(i => i.Preferenes.Any(p => p.UserId == clientId) ? 0 : 1)
                    .ThenBy(i => i.Name)
                    .Select(i => new IngredientResponse { Id = i.Id, Name = i.Name })
                    .Take(MaxCategoriesCount)
                    .ToListAsync();

            return data;
        }

        public async Task<List<IngredientResponse>> GetAllMatchingIngredients(string pattern)
        {
            string key = $"ingredients_{pattern}_{MaxCategoriesCount}";
            var data = await cacheService.GetData<List<IngredientResponse>>(key);

            if (data == null)
            {
                data = await inGreedDataContext.Ingredients
                    .Where(i => i.Name.ToLower().StartsWith(pattern.ToLower()))
                    .OrderBy(i => i.Name)
                    .Select(i => new IngredientResponse { Id = i.Id, Name = i.Name })
                    .Take(MaxCategoriesCount)
                    .ToListAsync();

                await cacheService.SetData(key, data);
            }

            return data;
        }

        public async Task<List<IngredientResponse>> GetAllMatchingIngredients(int clientId, string pattern)
        {
            var data = await inGreedDataContext.Ingredients
                    .Include(i => i.Preferenes)
                    .Where(i => i.Name.ToLower().StartsWith(pattern.ToLower()))
                    .Where(i => i.Preferenes.All(p => p.UserId != clientId || p.PreferenceType != Enums.PreferenceEnum.Allergen))
                    .OrderBy(i => i.Preferenes.Any(p => p.UserId == clientId) ? 0 : 1)
                    .ThenBy(i => i.Name)
                    .Select(i => new IngredientResponse { Id = i.Id, Name = i.Name })
                    .Take(MaxCategoriesCount)
                    .ToListAsync();

            return data;
        }
    }
}

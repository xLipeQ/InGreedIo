using InGreed_API.Dtos.Responses;
using InGreed_API.Dtos.Results;
using InGreed_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace InGreed_API.Services.Ingredients
{
    public interface IIngredientService
    {
        public Task<List<IngredientResponse>> GetAllIngredients();
        public Task<List<IngredientResponse>> GetProductIngredients(int productId);
        public Task<List<IngredientResponse>> GetAllMatchingIngredients(string pattern);
        public Task<List<IngredientResponse>> GetAllIngredients(int clientId);
        public Task<List<IngredientResponse>> GetAllMatchingIngredients(int clientId, string pattern);
    }
}

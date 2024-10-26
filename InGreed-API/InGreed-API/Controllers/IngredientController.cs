using InGreed_API.Dtos.Requests;
using InGreed_API.Dtos.Responses;
using InGreed_API.Enums;
using InGreed_API.Services.Ingredients;
using InGreed_API.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InGreed_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController(IIngredientService ingredientService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetIngredients(int? clientId)
        {
            List<IngredientResponse> ingredients;

            if (clientId is int id)
                ingredients = await ingredientService.GetAllIngredients(id);
            else
                ingredients = await ingredientService.GetAllIngredients();


            return Ok(ingredients);
        }


        [HttpGet]
        [Route("Product")]
        public async Task<IActionResult> GetIngredientsForProduct([FromQuery]int productId)
        {
            List<IngredientResponse> ingredients;

            ingredients = await ingredientService.GetProductIngredients(productId);

            return Ok(ingredients);
        }


        [HttpGet]
        [Route("Pattern")]
        public async Task<IActionResult> GetIngredientsStartingWith(int? clientId, string pattern)
        {
            List<IngredientResponse> ingredients;

            if (clientId is int id)
                ingredients = await ingredientService.GetAllMatchingIngredients(id, pattern);
            else
                ingredients = await ingredientService.GetAllMatchingIngredients(pattern);

            return Ok(ingredients);
        }
    }
}

using InGreed_API.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace InGreed_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            var ingredients = await categoryService.GetAllCategories();

            return Ok(ingredients);
        }

        [HttpGet]
        [Route("Pattern")]
        public async Task<IActionResult> GetIngredientsStartingWith(string pattern)
        {
            var ingredients = await categoryService.GetAllMatchingCategories(pattern);

            return Ok(ingredients);
        }
    }
}

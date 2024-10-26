using InGreed_API.Dtos;
using InGreed_API.Dtos.Requests;
using InGreed_API.Enums;
using InGreed_API.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace InGreed_API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController(IProductService productService) : Controller
    {
        [Authorize(Roles = nameof(UserRoleEnum.Client))]
        [HttpPost]
        [Route("FavouriteProduct")]
        public async Task<IActionResult> AddFavouriteProduct(FavouriteProductRequest favouriteProductRequest)
        {
            var result = await productService.AddFavouriteProduct(favouriteProductRequest);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = nameof(UserRoleEnum.Client))]
        [HttpDelete]
        [Route("FavouriteProduct")]
        public async Task<IActionResult> DeleteFavouriteProduct(FavouriteProductRequest favouriteProductRequest)
        {
            var result = await productService.DeleteFavouriteProduct(favouriteProductRequest);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = nameof(UserRoleEnum.Producent))]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProduct([FromForm]ProductAddRequest productAddRequest)
        {
            await productService.AddProduct(productAddRequest);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(ProductRequest productRequest)
        {
            Person person = null;

            if (User.Claims != null && User.Claims.Count() > 0)
            {
                var r = User.Claims.First(c => c.Type == ClaimTypes.Role).Value;
                if (r != null && productRequest.Id is int id)
                {
                    person = new Person() { Id = id, Role = (UserRoleEnum)Enum.Parse(typeof(UserRoleEnum), r) };
                }
            }

            var productRows = await productService.GetProducts(productRequest, person);

            return Ok(productRows);
        }

        [HttpGet]
        [Route("Image")]
        public async Task<IActionResult> GetImageForProduct(int productId)
        {
            var imageData = await productService.GetImageForProduct(productId);

            return new FileContentResult(imageData, "image/jpeg");
        }

    }
}

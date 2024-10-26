using InGreed_API.Dtos.Requests;
using InGreed_API.Enums;
using InGreed_API.Services.Ingredients;
using InGreed_API.Services.PreferenceService;
using InGreed_API.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InGreed_API.Controllers
{
    [Route("api/[controller]")]
    public class PreferenceController(IPreferenceService preferenceService) : Controller
    {
        [Authorize(Roles = nameof(UserRoleEnum.Client))]
        [HttpPost]
        public async Task<IActionResult> AddPreference([FromBody] PreferenceRequest preferenceRequest)
        {
            var result = await preferenceService.AddPreference(preferenceRequest);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = nameof(UserRoleEnum.Client))]
        [HttpGet]
        public async Task<IActionResult> GetPreference(MultiplePreferenceRequest preferenceRequest)
        {
            var preference = await preferenceService.GetPreference(preferenceRequest);

            return Ok(preference);
        }

        [Authorize(Roles = nameof(UserRoleEnum.Client))]
        [HttpGet("User")]
        public async Task<IActionResult> GetUserPreference(int userId)
        {
            var preference = await preferenceService.GetUserPreference(userId);

            return Ok(preference);
        }

        [Authorize(Roles = nameof(UserRoleEnum.Client))]
        [HttpDelete]
        public async Task<IActionResult> DeletePreference([FromBody] PreferenceRequest preferenceRequest)
        {
            var result = await preferenceService.RemovePreference(preferenceRequest);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }
    }
}

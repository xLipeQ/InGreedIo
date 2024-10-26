using InGreed_API.Dtos.Requests;
using InGreed_API.Enums;
using InGreed_API.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InGreed_API.Controllers
{
    [Route("api/[Controller]")]
    public class UserController(IUserService userService) : Controller
    {
        [HttpPost]
        [Authorize(Roles = nameof(UserRoleEnum.Administrator))]
        [Route("BanUser")]
        public async Task<IActionResult> BanUser(BanRequest banRequest)
        {
            var result = await userService.BanUser(banRequest);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return Ok();
        }
    }
}

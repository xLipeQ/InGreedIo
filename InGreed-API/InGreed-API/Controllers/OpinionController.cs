using InGreed_API.Services.OpinionService;
using InGreed_API.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InGreed_API.Dtos.Requests;

namespace InGreed_API.Controllers
{
    [Route("api/[controller]")]
    public class OpinionController(IOpinionService opinionService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetOpinionsForProduct([FromQuery] int productId)
        {
            var opinions = await opinionService.GetOpinionsForProduct(productId);
            return Ok(opinions);
        }

        [Authorize(Roles = nameof(UserRoleEnum.Client))]
        [HttpPost]
        public async Task<IActionResult> AddOpinion([FromBody] OpinionRequest opinionRequest)
        {
            var result = await opinionService.AddOpinion(opinionRequest);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = nameof(UserRoleEnum.Client))]
        [HttpPut]
        public async Task<IActionResult> ModifyOpinion(OpinionRequest opinionRequest)
        {
            var result = await opinionService.ModifyOpinion(opinionRequest);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [Authorize(Roles = nameof(UserRoleEnum.Client))]
        [HttpDelete]
        public async Task<IActionResult> DeleteOpinion(DeleteOpinionRequest deleteOpinionRequest)
        {
            var result = await opinionService.RemoveOpinion(deleteOpinionRequest);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }
    }
}

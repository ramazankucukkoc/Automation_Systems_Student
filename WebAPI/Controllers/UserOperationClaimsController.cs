using Application.Features.UserOperationClaims.Command.CreateUserOperationClaim;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimDto createUserOperationClaimDto)
        {
            CreateUserOperationClaimCommand createUserOperationClaimCommand = new() { CreateUserOperationClaim = createUserOperationClaimDto };
            var success = await Mediator.Send(createUserOperationClaimCommand);

            if (success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

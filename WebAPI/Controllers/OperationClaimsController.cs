using Application.Features.OperationClaims.Command.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OperationClaimDto operationClaimDto)
        {
            CreateOperationClaimCommand command = new() { OperationClaimDto = operationClaimDto };
            var success = await Mediator.Send(command);
            return Ok(success);
        }
    }
}

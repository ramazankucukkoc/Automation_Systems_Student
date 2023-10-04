using Application.Features.Auths.Command.Login;
using Application.Features.Auths.Command.Register;
using Application.Features.Users.Command;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetListUserQuery getListQuery = new();
            List<UserDto> result = await Mediator.Send(getListQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById([FromRoute] int userId)
        {
            GetByIdUserQuery getByIdUserQuery = new() { UserId = userId };
            UserDto result = await Mediator.Send(getByIdUserQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto };
            var success = await Mediator.Send(registerCommand);
            if (success == true)
            {
                return Ok();
            }
            return BadRequest();

        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand registerCommand = new() { UserForLoginDto = userForLoginDto };
            var success = await Mediator.Send(registerCommand);

            if (success)
            {
                return Ok();
            }
            return BadRequest();

        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            ForgotPasswordCommand forgotPasswordCommand = new() { ForgotPasswordDto = forgotPasswordDto };
            var result = await Mediator.Send(forgotPasswordCommand);
            if (result is false)
                return NotFound();

            return Ok(result);
        }
    }
}

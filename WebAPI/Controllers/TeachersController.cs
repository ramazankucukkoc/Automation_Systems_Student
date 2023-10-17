using Application.Features.Teachers.Command.CreateCommand;
using Application.Features.Teachers.Command.DeleteCommand;
using Application.Features.Teachers.Command.UpdateCommand;
using Application.Features.Teachers.Dtos;
using Application.Features.Teachers.Queries.GetAll;
using Application.Features.Teachers.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : BaseController
    {
        [HttpGet]
        [Route("{TCNo}")]
        public async Task<IActionResult> GetByTCNo([FromRoute] GetByTCNoQuery getByTCNoQuery)
        {
            var result = await Mediator.Send(getByTCNoQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllTeacherQuery getAllTeacherQuery = new();
            var result = await Mediator.Send(getAllTeacherQuery);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTeacherCommand createTeacherCommand)
        {
            CreateTeacherDto createTeacherDto = await Mediator.Send(createTeacherCommand);
            return Ok(createTeacherDto);
        }
        [HttpPost]
        [Route("{tcNo}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTeacherCommand deleteTeacherCommand)
        {
            DeleteTeacherDto deleteTeacherDto = await Mediator.Send(deleteTeacherCommand);
            return Ok(deleteTeacherDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateTeacherCommand updateTeacherCommand)
        {
            UpdateTeacherDto updateTeacherDto = await Mediator.Send(updateTeacherCommand);
            return Ok(updateTeacherDto);
        }
    }
}

using Application.Features.Courses.Command.CreateCommand;
using Application.Features.Courses.Queries.GetAll;
using Application.Features.Courses.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            GetByIdCourseQuery query = new();
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCourseCommand createCourseCommand)
        {
            var result = await Mediator.Send(createCourseCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllStudentCourseQuery query = new GetAllStudentCourseQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            GetAllCourseQuery query = new();
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}

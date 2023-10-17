using Application.Features.StudentCourses.Command.CreateCommand;
using Application.Features.StudentCourses.Command.DeleteCommand;
using Application.Features.StudentCourses.Command.UpdateCommand;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCoursesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStudentCourseCommand createStudentCourseCommand)
        {
            var result = await Mediator.Send(createStudentCourseCommand);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCourseCommand updateStudentCourseCommand)
        {
            var result = await Mediator.Send(updateStudentCourseCommand);
            return Ok(result);
        }
        [HttpPost]
        [Route("{CourseName}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteStudentCourseCommand deleteStudentCourseCommand)
        {
            var result = await Mediator.Send(deleteStudentCourseCommand);
            return Ok(result);
        }
    }
}

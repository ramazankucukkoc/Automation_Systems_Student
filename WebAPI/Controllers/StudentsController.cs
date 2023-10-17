using Application.Features.Courses.Queries.GetByMath;
using Application.Features.StudentCourses.Dtos;
using Application.Features.Students.Command.CreateCommand;
using Application.Features.Students.Command.DeleteCommand;
using Application.Features.Students.Command.UpdateCommand;
using Application.Features.Students.Dtos;
using Application.Features.Students.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMath()
        {
            GetAllMathQuery command = new();
            List<StudentCourseMath> getListsStudent = await Mediator.Send(command);
            return Ok(getListsStudent);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetListStudentCommand command = new();
            List<GetListStudentDto> getListsStudent = await Mediator.Send(command);
            return Ok(getListsStudent);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStudentCommand createStudentCommand)
        {
            CreateStudentDto createStudentDto = await Mediator.Send(createStudentCommand);
            return Ok(createStudentDto);
        }
        [HttpPost]
        [Route("{tcNo}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteStudentCommand deleteStudentCommand)
        {
            DeleteStudentDto deleteStudentDto = await Mediator.Send(deleteStudentCommand);
            return Ok(deleteStudentDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateCommandStudent updateCommandStudent)
        {
            UpdateStudentDto updateStudentDto = await Mediator.Send(updateCommandStudent);
            return Ok(updateStudentDto);
        }
    }

}

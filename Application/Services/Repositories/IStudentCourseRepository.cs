using Application.Features.Courses.Dtos;
using Application.Features.StudentCourses.Dtos;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IStudentCourseRepository : IAsyncRepository<StudentCourse>
    {
        Task<List<Student>> GetAllProcedure();
        Task<List<StudentCourseList>> GetStudentCourseLists();
        Task<List<StudentCourseMath>> GetStudentCourseMathOrderBy();
    }
}

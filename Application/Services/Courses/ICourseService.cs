using Domain.Entities;

namespace Application.Services.Courses
{
    public interface ICourseService
    {
        Task<Course> GetByCourseName(string courseName);
        Task<Course> GetById(int id);

    }
}

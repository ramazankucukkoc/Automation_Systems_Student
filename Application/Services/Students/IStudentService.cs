using Domain.Entities;

namespace Application.Services.Students
{
    public interface IStudentService
    {
        Task<Student> GetByTCNo(string tcNo);
        Task<Student> GetById(int id);
    }
}

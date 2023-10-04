using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class StudentCourseRepository : EfRepositoryBase<StudentCourse, AppDbContext>, IStudentCourseRepository
    {
        public StudentCourseRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}

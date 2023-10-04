using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class TeacherCourseRepository : EfRepositoryBase<TeacherCourse, AppDbContext>, ITeacherCourseRepository
    {
        public TeacherCourseRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}

using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CourseRepository : EfRepositoryBase<Course, AppDbContext>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
        }


    }

}

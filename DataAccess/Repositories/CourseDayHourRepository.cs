using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CourseDayHourRepository : EfRepositoryBase<CourseDayHour, AppDbContext>, ICourseDayHourRepository
    {
        public CourseDayHourRepository(AppDbContext context) : base(context)
        {
        }
    }
}

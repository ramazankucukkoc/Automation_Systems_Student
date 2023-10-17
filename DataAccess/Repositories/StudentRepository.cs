using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class StudentRepository : EfRepositoryBase<Student, AppDbContext>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }

}

using Application.Features.Teachers.Dtos;
using Application.Services.Repositories;
using Core.Domain;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class TeacherRepository : EfRepositoryBase<Teacher, AppDbContext>, ITeacherRepository
    {

        public TeacherRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List< ListTeacherDto>> GetTeacherOrderBy()
        {
            IQueryable<ListTeacherDto> listTeacherDtos = from u in Context.Users
                                                               join uo in Context.UserOperationClaims
                                                               on u.Id equals uo.UserId
                                                               join o in Context.OperationClaims
                                                               on uo.OperationClaimId equals o.Id
                                                               where o.Id==2
                                                               orderby u.FirstName
                                                               select new ListTeacherDto
                                                               {
                                                                   FirstName = u.FirstName,
                                                                   LastName = u.LastName,
                                                                   Email = u.Email,
                                                                   BirthDay = u.BirthDay,
                                                                   Id = u.Id,
                                                                   PhoneNo = u.PhoneNo,
                                                                   TCNo = u.TCNo
                                                               };
            return await listTeacherDtos.ToListAsync();


        }
    }

}

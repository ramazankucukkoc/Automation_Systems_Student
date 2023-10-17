using Application.Features.Teachers.Dtos;
using Core.Domain;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ITeacherRepository : IAsyncRepository<Teacher>
    {
        Task<List<ListTeacherDto>> GetTeacherOrderBy();

    }
}

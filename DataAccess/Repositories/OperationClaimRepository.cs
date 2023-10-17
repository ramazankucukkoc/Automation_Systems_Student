using Application.Services.Repositories;
using Core.Domain;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, AppDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(AppDbContext context) : base(context)
        {

        }

    }
}
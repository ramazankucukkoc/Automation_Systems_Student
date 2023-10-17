using Application.Services.Repositories;
using Core.Domain;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, AppDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(AppDbContext context) : base(context)
        {

        }

    }

}

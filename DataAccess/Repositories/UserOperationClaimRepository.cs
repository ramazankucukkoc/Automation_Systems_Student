using Application.Services.Repositories;
using Core.Domain;
using Core.Persistence.Repositories;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, AppDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(AppDbContext context) : base(context)
        {

        }

    }

}

using Application.Services.Repositories;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OperationClaims
{
    public class OperationCliamManager : IOperationClaimService
    {
        private readonly IOperationClaimRepository operationClaimRepository;

        public OperationCliamManager(IOperationClaimRepository operationClaimRepository)
        {
            this.operationClaimRepository = operationClaimRepository;
        }

        public async Task<OperationClaim> GetByOperationName(string name)
        {
            OperationClaim? operationClaim = await operationClaimRepository.GetAsync(o => o.Name.ToLower().Trim() == name.ToLower().Trim());
            if (operationClaim == null) { throw new Exception("Böyle rol kayıtlı değildir."); }
            return operationClaim;

        }
    }
}

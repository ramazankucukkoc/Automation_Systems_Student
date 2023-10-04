using Application.Services.Repositories;
using Core.Domain;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }
        public async Task<bool> GetOperationName(string operationName)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Name.ToLower().Trim() == operationName.ToLower().Trim());
            if (operationClaim == null)
            {
                return false;
            }
            return true;
        }
    }
}

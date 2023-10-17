using Core.Domain;

namespace Application.Services.OperationClaims
{
    public interface IOperationClaimService
    {
        Task<OperationClaim> GetByOperationName(string name);
    }
}

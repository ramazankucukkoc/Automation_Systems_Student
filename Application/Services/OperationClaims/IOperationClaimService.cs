using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OperationClaims
{
    public interface IOperationClaimService
    {
        Task<OperationClaim> GetByOperationName(string name);
    }
}

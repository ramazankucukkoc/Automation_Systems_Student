using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Command.CreateUserOperationClaim
{
    public class CreateUserOperationClaimDto
    {
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}

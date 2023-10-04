using Application.Services.OperationClaims;
using Application.Services.Repositories;
using Application.Services.Users;
using Core.Domain;
using MediatR;

namespace Application.Features.UserOperationClaims.Command.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<bool>
    {
        public CreateUserOperationClaimDto CreateUserOperationClaim { get; set; }
        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, bool>
        {
            private readonly IUserService _userService;
            private readonly IOperationClaimService _operationClaimService;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public CreateUserOperationClaimCommandHandler(IUserService userService,
                IOperationClaimService operationClaimService,
                IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userService = userService;
                _operationClaimService = operationClaimService;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<bool> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.GetByEmail(request.CreateUserOperationClaim.Email);
                OperationClaim operationClaim = await _operationClaimService.GetByOperationName(request.CreateUserOperationClaim.RoleName);
                if (user == null || operationClaim == null)
                    return false;

                UserOperationClaim userOperationClaim = new()
                {
                    OperationClaimId = operationClaim.Id,
                    UserId = user.Id,
                };
                await _userOperationClaimRepository.AddAsync(userOperationClaim);
                return true;

            }
        }
    }
}

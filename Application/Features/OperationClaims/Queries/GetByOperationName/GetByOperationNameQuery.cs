using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.OperationClaims;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetByOperationName
{
    public class GetByOperationNameQuery : IRequest<bool>
    {
        public OperationClaimDto OperationClaimDto { get; set; }

        public class GetByOperationNameQueryHandler : IRequestHandler<GetByOperationNameQuery, bool>
        {
            private readonly IOperationClaimService _operationClaimService;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public GetByOperationNameQueryHandler(IOperationClaimService operationClaimService, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimService = operationClaimService;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<bool> Handle(GetByOperationNameQuery request, CancellationToken cancellationToken)
            {
                await _operationClaimService.GetByOperationName(request.OperationClaimDto.Name);
                return true;


            }
        }
    }
}

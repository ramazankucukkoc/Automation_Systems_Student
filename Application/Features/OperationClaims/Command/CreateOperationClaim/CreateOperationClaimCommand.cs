using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain;
using MediatR;

namespace Application.Features.OperationClaims.Command.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<string>
    {
        public OperationClaimDto OperationClaimDto { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, string>
        {
            private readonly IOperationClaimRepository _repository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
            private readonly IMapper _mapper;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository repository,
                OperationClaimBusinessRules operationClaimBusinessRules,IMapper mapper)
            {
                _mapper =mapper;
                _repository = repository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            async Task<string> IRequestHandler<CreateOperationClaimCommand, string>.Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                bool IsOperationName = await _operationClaimBusinessRules.GetOperationName(request.OperationClaimDto.Name);
                if (IsOperationName)
                {
                    return $"Daha önce eklenmiş rol {request.OperationClaimDto.Name}";
                }
                OperationClaim operationClaim =_mapper.Map<OperationClaim>(request.OperationClaimDto);
                await _repository.AddAsync(operationClaim);
                return "İşlem Başarılı şekilde eklendi";
            }
        }


    }
}

using Application.Features.Auths.Command.Register;
using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain;
using MediatR;

namespace Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQuery:IRequest<UserDto>
    {
        public int UserId { get; set; }

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;

            public GetByIdUserQueryHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<UserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Id == request.UserId);
                UserDto userListDto = _mapper.Map<UserDto >(user);
                return userListDto;

            }
        }
    }
}

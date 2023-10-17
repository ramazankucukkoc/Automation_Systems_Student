using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Types;
using MediatR;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListUserQuery : IRequest<List<UserDto>>
    {

        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, List<UserDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<List<UserDto>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                var users = await _userRepository.GetListAsync();
                if (users == null) throw new BusinessException("Kayıt Bulunamadı....");

                var response = _mapper.Map<List<UserDto>>(users);
                return response;

            }
        }


    }
}

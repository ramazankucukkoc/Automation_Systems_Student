using Application.Features.Teachers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Types;
using MediatR;

namespace Application.Features.Teachers.Queries.GetAll
{
    public class GetAllTeacherQuery : IRequest<List<ListTeacherDto>>
    {
        public class GetAllTeacherQueryHandler : IRequestHandler<GetAllTeacherQuery, List<ListTeacherDto>>
        {
            private readonly IMapper _mapper;
            private readonly ITeacherRepository _repository;
            private readonly IUserRepository _userRepository;
            public GetAllTeacherQueryHandler(IMapper mapper, ITeacherRepository repository,IUserRepository userRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<List<ListTeacherDto>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
            {
                List<ListTeacherDto> teachers = await _repository.GetTeacherOrderBy();
                if (teachers is null) throw new BusinessException("Kayıt Bulunamadı....");

                return teachers;
            }
        }

    }
}

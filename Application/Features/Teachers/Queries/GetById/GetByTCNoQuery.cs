using Application.Features.Teachers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Queries.GetById
{
    public class GetByTCNoQuery : IRequest<ListTeacherDto>
    {
        public string TCNo { get; set; }
        public class GetByTCNoQueryHandler : IRequestHandler<GetByTCNoQuery, ListTeacherDto>
        {
            private readonly IMapper _mapper;
            private readonly ITeacherRepository _teacherRepository;

            public GetByTCNoQueryHandler(IMapper mapper, ITeacherRepository teacherRepository)
            {
                _mapper = mapper;
                _teacherRepository = teacherRepository;
            }

            public async Task<ListTeacherDto> Handle(GetByTCNoQuery request, CancellationToken cancellationToken)
            {
                Teacher? teacher = await _teacherRepository.GetAsync(t => t.TCNo == request.TCNo);
                if (teacher is null) throw new BusinessException("Kayıt Bulunamadı");

                ListTeacherDto listTeacherDto = _mapper.Map<ListTeacherDto>(teacher);
                return listTeacherDto;

            }
        }
    }
}

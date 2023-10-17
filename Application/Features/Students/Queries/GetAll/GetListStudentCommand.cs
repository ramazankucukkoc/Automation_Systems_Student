using Application.Features.Students.Dtos;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Queries.GetAll
{
    public class GetListStudentCommand : IRequest<List<GetListStudentDto>>
    {
        public class GetListStudentHandler : IRequestHandler<GetListStudentCommand, List<GetListStudentDto>>
        {
            private readonly IMapper _mapper;
            private readonly IStudentRepository _studentRepository;
            private readonly StudentBusinessRules _studentBusinessRules;

            public GetListStudentHandler(IMapper mapper, IStudentRepository studentRepository, StudentBusinessRules studentBusinessRules)
            {
                _mapper = mapper;
                _studentRepository = studentRepository;
                _studentBusinessRules = studentBusinessRules;
            }

            public async Task<List<GetListStudentDto>> Handle(GetListStudentCommand request, CancellationToken cancellationToken)
            {
                List<Student> students = await _studentRepository.GetListAsync();

                await _studentBusinessRules.GetAllOrNull(students);
                List<GetListStudentDto> getListStudentDtos = _mapper.Map<List<GetListStudentDto>>(students);
                return getListStudentDtos;


            }
        }
    }
}

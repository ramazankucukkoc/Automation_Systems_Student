using Application.Features.Auths.Rules;
using Application.Features.Students.Dtos;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Command.CreateCommand
{
    public class CreateStudentCommand : IRequest<CreateStudentDto>
    {
        public string TCNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentDto>
        {
            private readonly IMapper _mapper;
            private readonly IStudentRepository _studentRepository;
            private readonly StudentBusinessRules _studentBusinessRules;
            private readonly AuthBusinessRules _authBusinessRules;

            public CreateStudentCommandHandler(IMapper mapper, IStudentRepository studentRepository, StudentBusinessRules studentBusinessRules, AuthBusinessRules authBusinessRules)
            {
                _authBusinessRules = authBusinessRules;
                _mapper = mapper;
                _studentRepository = studentRepository;
                _studentBusinessRules = studentBusinessRules;
            }

            public async Task<CreateStudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {
                Student student = _mapper.Map<Student>(request);
                await _studentBusinessRules.StudentIsExistsCreate(student.TCNo);


                //await _studentBusinessRules.StudentIsExistsEmail(student.Email);
                await _authBusinessRules.UserEmailShouldBeNotExists(student.Email);

                await _studentRepository.AddAsync(student);
                CreateStudentDto createStudentDto = _mapper.Map<CreateStudentDto>(student);
                return createStudentDto;

            }
        }
    }
}

using Application.Features.Auths.Rules;
using Application.Features.Students.Dtos;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Command.UpdateCommand
{
    public class UpdateCommandStudent : IRequest<UpdateStudentDto>
    {
        public string TCNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public class UpdateCommandStudentHandler : IRequestHandler<UpdateCommandStudent, UpdateStudentDto>
        {
            private readonly IMapper _mapper;
            private readonly StudentBusinessRules _studentBusinessRules;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IStudentRepository _studentRepository;

            public UpdateCommandStudentHandler(IMapper mapper, StudentBusinessRules studentBusinessRules, AuthBusinessRules authBusinessRules, IStudentRepository studentRepository)
            {
                _mapper = mapper;
                _studentBusinessRules = studentBusinessRules;
                _authBusinessRules = authBusinessRules;
                _studentRepository = studentRepository;
            }

            public async Task<UpdateStudentDto> Handle(UpdateCommandStudent request, CancellationToken cancellationToken)
            {
                Student student = await _studentBusinessRules.StudentIsExists(request.TCNo);
                await _authBusinessRules.UserEmailShouldBeNotExists(request.Email);
                await _studentBusinessRules.StudentIsExistsEmail(request.Email, student.Id);
                Student? getById = await _studentRepository.GetAsync(s => s.TCNo == request.TCNo);

                _mapper.Map(request, getById);
                await _studentRepository.UpdateAsync(getById);
                UpdateStudentDto updateStudentDto = _mapper.Map<UpdateStudentDto>(getById);
                return updateStudentDto;

            }
        }


    }
}

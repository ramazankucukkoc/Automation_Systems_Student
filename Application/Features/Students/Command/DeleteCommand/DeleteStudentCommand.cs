using Application.Features.Students.Dtos;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Command.DeleteCommand
{
    public class DeleteStudentCommand : IRequest<DeleteStudentDto>
    {
        public string TCNo { get; set; }

        public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, DeleteStudentDto>
        {
            private readonly IMapper _mapper;
            private readonly StudentBusinessRules _studentBusinessRules;
            private readonly IStudentRepository _studentRepository;

            public DeleteStudentCommandHandler(IMapper mapper, StudentBusinessRules studentBusinessRules, IStudentRepository studentRepository)
            {
                _mapper = mapper;
                _studentBusinessRules = studentBusinessRules;
                _studentRepository = studentRepository;
            }

            async Task<DeleteStudentDto> IRequestHandler<DeleteStudentCommand, DeleteStudentDto>.Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
            {
                Student? student = await _studentRepository.GetAsync(u => u.TCNo.ToLower().Trim() == request.TCNo.ToLower().Trim());
                await _studentBusinessRules.StudentIsExists(request.TCNo);
                Student deletedStudent = await _studentRepository.DeleteAsync(student);
                DeleteStudentDto deleteStudentDto = _mapper.Map<DeleteStudentDto>(deletedStudent);
                return deleteStudentDto;


            }
        }
    }
}

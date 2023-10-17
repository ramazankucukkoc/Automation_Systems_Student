using Application.Features.Teachers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Command.DeleteCommand
{
    public class DeleteTeacherCommand : IRequest<DeleteTeacherDto>
    {
        public string TCNo { get; set; }
        public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, DeleteTeacherDto>
        {
            private readonly IMapper _mapper;
            private readonly ITeacherRepository _teacherRepository;

            public DeleteTeacherCommandHandler(IMapper mapper, ITeacherRepository teacherRepository)
            {
                _mapper = mapper;
                _teacherRepository = teacherRepository;
            }

            public async Task<DeleteTeacherDto> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
            {
                Teacher? teacher = await _teacherRepository.GetAsync(u => u.TCNo.ToLower().Trim() == request.TCNo.ToLower().Trim());
                //  await _studentBusinessRules.StudentIsExists(request.TCNo);
                Teacher deletedTeacher = await _teacherRepository.DeleteAsync(teacher);
                DeleteTeacherDto deleteTeacherDto = _mapper.Map<DeleteTeacherDto>(deletedTeacher);
                return deleteTeacherDto;
            }
        }
    }
}
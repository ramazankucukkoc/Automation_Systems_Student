using Application.Features.StudentCourses.Dtos;
using Application.Features.StudentCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentCourses.Command.CreateCommand
{
    public class CreateStudentCourseCommand : IRequest<StudentCourseAddDto>
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Note1 { get; set; }
        public double Note2 { get; set; }
        public class CreateStudentCourseCommandHandler : IRequestHandler<CreateStudentCourseCommand, StudentCourseAddDto>
        {

            private readonly IMapper _mapper;
            private readonly IStudentCourseRepository _studentCourseRepository;
            private readonly StudentCourseBusinessRules _studentCourseBusinessRules;

            public CreateStudentCourseCommandHandler(IMapper mapper
                , IStudentCourseRepository studentCourseRepository, StudentCourseBusinessRules studentCourseBusinessRules)
            {
                _studentCourseRepository = studentCourseRepository;
                _studentCourseBusinessRules = studentCourseBusinessRules;
                _mapper = mapper;
            }

            public async Task<StudentCourseAddDto> Handle(CreateStudentCourseCommand request, CancellationToken cancellationToken)
            {
                await _studentCourseBusinessRules.StudentCourseIsNotAdd(request.StudentId, request.CourseId);

                StudentCourse studentCourse = await _studentCourseRepository.AddAsync(new StudentCourse
                {
                    CourseId = request.CourseId,
                    StudentId = request.StudentId,
                    Note1 = request.Note1,
                    Note2 = request.Note2,
                    Active = true,
                });
                StudentCourseAddDto studentCourseAddDto = _mapper.Map<StudentCourseAddDto>(studentCourse);
                return studentCourseAddDto;
            }
        }
    }
}

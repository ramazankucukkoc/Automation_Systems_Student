using Application.Features.StudentCourses.Dtos;
using Application.Features.StudentCourses.Rules;
using Application.Services.Courses;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentCourses.Command.UpdateCommand
{
    public class UpdateStudentCourseCommand : IRequest<StudentCourseUpdateDto>
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Note1 { get; set; }
        public double Note2 { get; set; }
        public class UpdateStudentCourseCommandHandler : IRequestHandler<UpdateStudentCourseCommand, StudentCourseUpdateDto>
        {
            private readonly IMapper _mapper;
            private readonly IStudentCourseRepository _studentCourseRepository;
            private readonly ICourseService _courseService;
            private readonly StudentCourseBusinessRules _studentCourseBusinessRules;

            public UpdateStudentCourseCommandHandler(IMapper mapper,
                IStudentCourseRepository studentCourseRepository, ICourseService courseService, StudentCourseBusinessRules studentCourseBusinessRules)
            {
                _studentCourseBusinessRules = studentCourseBusinessRules;
                _courseService = courseService;
                _mapper = mapper;
                _studentCourseRepository = studentCourseRepository;
            }

            public async Task<StudentCourseUpdateDto> Handle(UpdateStudentCourseCommand request, CancellationToken cancellationToken)
            {

                StudentCourse? studentCourse = await _studentCourseBusinessRules.StudentCourseIsExists(request.StudentId, request.CourseId);

                studentCourse.Note1 = request.Note1;
                studentCourse.Note2 = request.Note2;

                await _studentCourseRepository.UpdateAsync(studentCourse);
                StudentCourseUpdateDto studentCourseUpdateDto = _mapper.Map<StudentCourseUpdateDto>(studentCourse);
                return studentCourseUpdateDto;
            }
        }
    }
}

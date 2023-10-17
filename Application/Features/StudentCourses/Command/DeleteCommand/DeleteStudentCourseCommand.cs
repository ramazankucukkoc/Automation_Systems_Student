using Application.Features.StudentCourses.Dtos;
using Application.Services.Courses;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentCourses.Command.DeleteCommand
{
    public class DeleteStudentCourseCommand : IRequest<StudentCourseDeleteDto>
    {
        public string CourseName { get; set; }

        public class DeleteStudentCourseCommandHandler : IRequestHandler<DeleteStudentCourseCommand, StudentCourseDeleteDto>
        {
            private readonly IMapper _mapper;
            private readonly ICourseService _courseService;
            private readonly IStudentCourseRepository _studentCourseRepository;

            public DeleteStudentCourseCommandHandler(IMapper mapper, ICourseService courseService, IStudentCourseRepository studentCourseRepository)
            {
                _mapper = mapper;
                _courseService = courseService;
                _studentCourseRepository = studentCourseRepository;
            }

            public async Task<StudentCourseDeleteDto> Handle(DeleteStudentCourseCommand request, CancellationToken cancellationToken)
            {
                Course course = await _courseService.GetByCourseName(request.CourseName);
                StudentCourse? studentCourse = await _studentCourseRepository.GetAsync(sc => sc.CourseId == course.Id);
                if (studentCourse is null) throw new BusinessException("Böyle bir kayıt mevcut değildir.");

                StudentCourse studentCourseDeleted = await _studentCourseRepository.DeleteAsync(studentCourse);
                StudentCourseDeleteDto studentCourseDeleteDto = _mapper.Map<StudentCourseDeleteDto>(studentCourseDeleted);
                return studentCourseDeleteDto;

            }
        }
    }
}

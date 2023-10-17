using Application.Services.Courses;
using Application.Services.Repositories;
using Application.Services.Students;
using Core.CrossCuttingConcerns.Types;
using Domain.Entities;

namespace Application.Features.StudentCourses.Rules
{
    public class StudentCourseBusinessRules
    {
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        public StudentCourseBusinessRules(IStudentCourseRepository studentCourseRepository, IStudentService studentService, ICourseService courseService)
        {
            _courseService = courseService;
            _studentService = studentService;
            _studentCourseRepository = studentCourseRepository;
        }
        public async Task<StudentCourse> StudentCourseIsNotAdd(int studentId, int courseId)
        {
            StudentCourse? studentCourse = await _studentCourseRepository.GetAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            Student student = await _studentService.GetById(studentId);
            Course course = await _courseService.GetById(courseId);
            if (studentCourse is not null) throw new BusinessException($"{student.FirstName + " " + student.LastName} isimli ögrencini {course.Name} dersi eklenmiştir bir daha eklenemez");

            return studentCourse;

        }
        public async Task<StudentCourse> StudentCourseIsExists(int studentId, int courseId)
        {
            StudentCourse? studentCourse = await _studentCourseRepository.GetAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);

            if (studentCourse == null) throw new BusinessException("Kayıt Bulunamadı");

            return studentCourse;

        }
    }
}

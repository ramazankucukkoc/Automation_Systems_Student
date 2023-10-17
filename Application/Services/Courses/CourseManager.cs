using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Types;
using Domain.Entities;

namespace Application.Services.Courses
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> GetByCourseName(string courseName)
        {
            Course? course = await _courseRepository.GetAsync(c => c.Name.ToLower().Trim() == courseName.ToLower().Trim());
            if (course is null) throw new BusinessException("Böyle ders mevcut değildir....");

            return course;

        }

        public async Task<Course> GetById(int id)
        {
            Course? course = await _courseRepository.GetAsync(c => c.Id == id);
            if (course is null) throw new BusinessException("Böyle ders mevcut değildir....");

            return course;
        }
    }
}

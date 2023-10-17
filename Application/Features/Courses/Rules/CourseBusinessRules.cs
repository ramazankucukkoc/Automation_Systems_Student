using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Types;
using Domain.Entities;

namespace Application.Features.Courses.Rules
{
    public class CourseBusinessRules
    {
        private readonly ICourseDayHourRepository _courseDayHourRepository;

        public CourseBusinessRules(ICourseDayHourRepository courseDayHourRepository)
        {
            _courseDayHourRepository = courseDayHourRepository;
        }

        public async Task<CourseDayHour> IsExists(CourseDayHour courseDayHour)
        {
            CourseDayHour? courseDayHourgetList = await _courseDayHourRepository.GetAsync(x => x.HourId == courseDayHour.HourId && x.HourId == courseDayHour.HourId && x.CourseId == courseDayHour.CourseId);
            if (courseDayHourgetList is not null) throw new BusinessException("Liste eklendiğiniz günü programı mevcuttur..");

            return courseDayHour;
        }
    }
}

namespace Application.Features.Courses.Dtos
{
    public class CreateCourseDayHourDto
    {
        public int Id { get; set; }
        public int HourId { get; set; }
        public int DayId { get; set; }
        public int CourseId { get; set; }
    }
}

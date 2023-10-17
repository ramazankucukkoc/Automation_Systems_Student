using Core.Domain;

namespace Domain.Entities
{
    public class CourseDayHour : Entity
    {
        public int HourId { get; set; }
        public int DayId { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public CourseDayHour()
        {

        }
        public CourseDayHour(int id, int hourId, int courseId, int dayId) : base(id)
        {
            HourId = hourId;
            DayId = dayId;
            CourseId = courseId;

        }
    }
}

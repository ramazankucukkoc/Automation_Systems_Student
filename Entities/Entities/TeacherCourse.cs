using Core.Domain;

namespace Domain.Entities
{
    public class TeacherCourse : Entity
    {
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public TeacherCourse()
        {

        }
        public TeacherCourse(int id, int teacherId, int courseId) : base(id)
        {
            TeacherId = teacherId;
            CourseId = courseId;

        }
    }
}

using Core.Domain;

namespace Domain.Entities
{
    public class StudentCourse : Entity
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Note { get; set; }

        public StudentCourse()
        {

        }
        public StudentCourse(int id, int studentId, int courseId) : base(id)
        {
            StudentId = studentId;
            CourseId = courseId;
        }

    }
}

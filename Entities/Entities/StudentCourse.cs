using Core.Domain;

namespace Domain.Entities
{
    public class StudentCourse : Entity
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Note1 { get; set; }
        public double Note2 { get; set; }
        public StudentCourse()
        {

        }
        public StudentCourse(int id, int studentId, int courseId, double note1, double note2) : base(id)
        {
            StudentId = studentId;
            CourseId = courseId;
            Note1 = note1;
            Note2 = note2;
        }

    }
}

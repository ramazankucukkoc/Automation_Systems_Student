namespace Application.Features.StudentCourses.Dtos
{
    public class StudentCourseMath
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string StudentName { get; set; }
        public double Note1 { get; set; }
        public double Note2 { get; set; }
        public double Average { get; set; }
        public string Status => Average >= 50 ? "Geçti" : "Kaldı";
    }
}

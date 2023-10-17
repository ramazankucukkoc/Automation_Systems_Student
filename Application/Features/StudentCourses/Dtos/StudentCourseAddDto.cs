namespace Application.Features.StudentCourses.Dtos
{
    public class StudentCourseAddDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Note1 { get; set; }
        public double Note2 { get; set; }


    }
}

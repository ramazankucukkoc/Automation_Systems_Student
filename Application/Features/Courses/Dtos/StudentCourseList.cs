namespace Application.Features.Courses.Dtos
{
    public class StudentCourseList
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string TCNo { get; set; }
        // public int Yas { get; set; }
        public string CourseName { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public double Note1 { get; set; }
        public double Note2 { get; set; }
        public double Average { get; set; }
        public string Status => Average >= 50 ? "Geçti" : "Kaldı";





    }

}

using Core.Domain;

namespace Domain.Entities
{
    public class Student : Entity
    {
        public string TCNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }
        public Student(int id, string lastName, string firstName, DateTime birthDay, string phoneNo, string email) : this()
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            BirthDay = birthDay;
            PhoneNo = phoneNo;
            Email = email;
        }
    }
}

using Core.Domain;

namespace Domain.Entities
{
    public class Teacher : Entity
    {
        public string TCNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; }

        public Teacher()
        {
            TeacherCourses = new HashSet<TeacherCourse>();
        }
        public Teacher(int id, string tcNo, string firstName, string lastName, DateTime birthDay, string email, string phoneNo, byte[] passwordSalt,
           byte[] passwordHash) : this()
        {

            Id = id;
            TCNo = tcNo;
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            Email = email;
            PhoneNo = phoneNo;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

    }
}

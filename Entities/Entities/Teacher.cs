using Core.Domain;

namespace Domain.Entities
{
    public class Teacher : Entity
    {
        public string TCNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlaceOfBirth { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; }

        public Teacher()
        {
            TeacherCourses=new HashSet<TeacherCourse>();
        }
        public Teacher(int id, string tcNo, string firstName, string lastName, string placeOfBirth) : this()
        {
            Id = id;
            TCNo = tcNo;
            FirstName = firstName;
            LastName = lastName;
            PlaceOfBirth = placeOfBirth;
        }

    }
}

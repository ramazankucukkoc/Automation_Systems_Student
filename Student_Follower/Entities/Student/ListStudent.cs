using System;

namespace Student_Follower.Entities
{
    public class ListStudent
    {
        public int Id { get; set; }
        public string TCNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int Yas
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDay.Year;
                return age;
            }
        }


    }
}

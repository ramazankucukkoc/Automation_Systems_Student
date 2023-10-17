namespace Core.Domain
{
    public class User : Entity
    {
        public string TCNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNo { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }
        public User(int id, string firstName, string lastName, string email, byte[] passwordSalt,
           byte[] passwordHash, bool status,string tcNo,DateTime birthDay,string phoneNo) : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
            TCNo = tcNo;
            BirthDay = birthDay;
            PhoneNo = phoneNo;
        }
    }
}

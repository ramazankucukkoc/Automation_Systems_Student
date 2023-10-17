﻿namespace Application.Features.Teachers.Dtos
{
    public class DeleteTeacherDto
    {
        public int Id { get; set; }
        public string TCNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
}

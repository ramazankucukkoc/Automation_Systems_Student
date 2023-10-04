using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course:Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Hour { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }
        public Course(int id,string name,string code,int hour):this()
        {
            Id = id;
            Name = name;
            Code = code;
            Hour = hour;
        }
    }
}

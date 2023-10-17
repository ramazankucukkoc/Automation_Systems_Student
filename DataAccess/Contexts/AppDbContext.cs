using Core.Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = RAMAZANKUCUKKOC; Initial Catalog = tempdb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<CourseDayHour> CourseDayHours { get; set; }

    }

}

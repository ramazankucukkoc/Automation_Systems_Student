using Application.Features.Courses.Dtos;
using Application.Features.StudentCourses.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class StudentCourseRepository : EfRepositoryBase<StudentCourse, AppDbContext>, IStudentCourseRepository
    {
        public StudentCourseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Student>> GetAllProcedure()
        {
            var students = await Context.Students.FromSqlRaw("exec sp_get_student_full").ToListAsync();
            return students;
        }

        public async Task<List<StudentCourseList>> GetStudentCourseLists()
        {
            IQueryable<StudentCourseList> result = from sc in Context.StudentCourses
                                                   join s in Context.Students
                                                   on sc.StudentId equals s.Id
                                                   join c in Context.Courses
                                                   on sc.CourseId equals c.Id
                                                   orderby s.FirstName
                                                   select new StudentCourseList
                                                   {
                                                       StudentId = s.Id,
                                                       CourseId = c.Id,
                                                       TCNo = s.TCNo,
                                                       CourseName = c.Name,
                                                       Email = s.Email,
                                                       Note1 = sc.Note1,
                                                       Note2 = sc.Note2,
                                                       PhoneNo = s.PhoneNo,
                                                       StudentName = s.FirstName + " " + s.LastName,
                                                       Average = (sc.Note1 + sc.Note2) / 2,
                                                   };
            return await result.ToListAsync();

        }

        public async Task<List<StudentCourseMath>> GetStudentCourseMathOrderBy()
        {
            IQueryable<StudentCourseMath> result = from sc in Context.StudentCourses
                                                   join s in Context.Students
                                                   on sc.StudentId equals s.Id
                                                   join c in Context.Courses
                                                   on sc.CourseId equals c.Id
                                                   orderby ((sc.Note1 + sc.Note2) / 2) descending
                                                   select new StudentCourseMath
                                                   {
                                                       StudentId = s.Id,
                                                       CourseId = c.Id,
                                                       CourseName = c.Name,
                                                       Note1 = sc.Note1,
                                                       Note2 = sc.Note2,
                                                       StudentName = s.FirstName + " " + s.LastName,
                                                       Average = (sc.Note1 + sc.Note2) / 2,
                                                   };
            return await result.ToListAsync();
        }
    }

}

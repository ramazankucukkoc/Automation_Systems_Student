using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable(nameof(StudentCourse));
            builder.HasNoKey();
            builder.Property(uo => uo.StudentId).HasColumnName("StudentId");
            builder.Property(uo => uo.CourseId).HasColumnName("CourseId");
            builder.HasOne(sc => sc.Student);
            builder.HasOne(sc => sc.Course);
        }
    }
}

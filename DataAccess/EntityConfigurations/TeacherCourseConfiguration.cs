using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class TeacherCourseConfiguration : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> builder)
        {
            builder.ToTable(nameof(TeacherCourse));
            builder.HasNoKey();
            builder.HasOne(t => t.Teacher);
            builder.HasOne(t => t.Course);

        }
    }
}

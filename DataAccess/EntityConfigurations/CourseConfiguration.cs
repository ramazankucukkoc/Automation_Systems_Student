using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses").HasKey(x => x.Id);
            builder.Property(c => c.Name).HasColumnName("Name");
            builder.Property(c => c.Code).HasColumnName("Code");
            builder.Property(c => c.Hour).HasColumnName("Hour");

        }
    }
}

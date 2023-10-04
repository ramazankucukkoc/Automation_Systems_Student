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
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students").HasKey(x => x.Id);
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u=>u.FirstName).HasColumnName("FirstName");
            builder.Property(u=>u.LastName).HasColumnName("LastName");
            builder.Property(u=>u.TCNo).HasColumnName("TCNo");
            builder.Property(u=>u.PhoneNo).HasColumnName("PhoneNo");
            builder.Property(u=>u.Email).HasColumnName("Email");



        }
    }
}

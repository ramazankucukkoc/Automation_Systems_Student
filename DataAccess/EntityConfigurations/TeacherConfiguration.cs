using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers").HasKey(x => x.Id);
            //   builder.Property(t=>t.Id).UseJetIdentityColumn();
            builder.Property(t => t.FirstName).HasColumnName("FirstName");
            builder.Property(t => t.TCNo).HasColumnName("TCNo");
            builder.Property(t => t.LastName).HasColumnName("LastName");
            builder.Property(t => t.BirthDay).HasColumnName("BirthDay");

        }
    }
}

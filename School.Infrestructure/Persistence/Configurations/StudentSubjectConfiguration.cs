using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Infrestructure.Persistence.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.ToTable("StudentSubject");

            builder.HasKey(e => new { e.StudId, e.SubId }).HasName("Pk_StudId_SubId");

            //---------------------------------------------------------------


        }
    }
}

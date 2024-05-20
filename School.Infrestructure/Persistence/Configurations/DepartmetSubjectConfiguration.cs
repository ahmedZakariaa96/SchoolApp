using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Infrestructure.Persistence.Configurations
{
    public class DepartmetSubjectConfiguration : IEntityTypeConfiguration<DepartmetSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmetSubject> builder)
        {
            builder.ToTable("DepartmetSubject");

            builder.HasKey(e => new { e.DepID, e.SubId }).HasName("Pk_DepID_SubId");

            //---------------------------------------------------------------


        }
    }
}

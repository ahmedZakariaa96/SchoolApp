using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Infrestructure.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");


            builder.HasKey(e => e.StudId).HasName("Pk_StudId");
            builder.Property(e => e.StudId).ValueGeneratedOnAdd();

            //---------------------------------------------------------------
            builder.HasOne(e => e.Department)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.DepId)
                .OnDelete(DeleteBehavior.Restrict);
            //---------------------------------------------------------------
            builder.Property(e => e.NameEn).HasMaxLength(100);
            builder.Property(e => e.NameAr).HasMaxLength(100);
            builder.Property(e => e.Phone).HasMaxLength(100);
            builder.Property(e => e.Address).HasMaxLength(100);


        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.View;

namespace School.Infrestructure.Persistence.Configurations
{
    public class VW_StudentsConfiguration : IEntityTypeConfiguration<VW_Student>
    {
        public void Configure(EntityTypeBuilder<VW_Student> builder)
        {
            builder.ToView("VW_Student");
            builder.HasNoKey();

        }
    }
}

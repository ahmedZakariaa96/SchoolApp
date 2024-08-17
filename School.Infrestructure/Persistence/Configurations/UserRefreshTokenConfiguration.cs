using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Infrestructure.Persistence.Configurations
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.ToTable("UserRefreshToken");


            builder.HasKey(e => e.Id).HasName("Pk_UserRefreshToken");
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            //---------------------------------------------------------------
            builder.HasOne(e => e.user)
                .WithMany(x => x.UserRefreshTokens)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            //---------------------------------------------------------------



        }
    }
}

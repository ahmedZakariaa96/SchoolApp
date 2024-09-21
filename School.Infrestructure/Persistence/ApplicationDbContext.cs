using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.Entities.IdentityServer;

namespace School.Infrestructure.Persistence
{
    public partial class ApplicationDbContext : IdentityDbContext<User>
    {
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<DepartmetSubject> DepartmetSubjects { get; set; }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<UserRefreshToken> UserRefreshes { get; set; }


        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

        public ApplicationDbContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}

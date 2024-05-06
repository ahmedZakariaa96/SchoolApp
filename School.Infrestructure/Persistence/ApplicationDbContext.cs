using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrestructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<DepartmetSubject> DepartmetSubjects { get; set; }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

        public ApplicationDbContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
      
 
    }
}

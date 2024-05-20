using System.ComponentModel.DataAnnotations;

namespace School.Domain.Entities
{
    public class Subject
    {
        [Key]
        public int SubId { get; set; }
        [StringLength(500)]
        public required string SubjectNmae { get; set; }

        public DateTime? Period { get; set; }
        public virtual ICollection<DepartmetSubject> DepartmetSubjects { get; set; } = new HashSet<DepartmetSubject>();
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new HashSet<StudentSubject>();


    }
}

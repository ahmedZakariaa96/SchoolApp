using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }
        [StringLength(500)]
        public required string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<DepartmetSubject> DepartmetSubject { get; set; } = new HashSet<DepartmetSubject>();


    }
}

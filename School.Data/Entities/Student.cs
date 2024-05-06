using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Student
    {
        [Key]
        public int StudId { get; set; }
        [StringLength(500)]
        public required string Name { get; set; }
        [StringLength(500)]
        public required string Phone { get; set; }
        [StringLength(500)]
        public required string Address { get; set; }
        public int? DepId { get; set; }
        [ForeignKey("DepId")]
        public virtual Department? Department { get; set; }





    }
}

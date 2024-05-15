using School.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities
{
    public class Student : GenericLocalizable
    {
        [Key]
        public int StudId { get; set; }
        [StringLength(500)]
        public required string NameEn { get; set; }
        public required string NameAr { get; set; }

        [StringLength(500)]
        public required string Phone { get; set; }
        [StringLength(500)]
        public required string Address { get; set; }
        public int? DepId { get; set; }
        [ForeignKey("DepId")]
        public virtual Department? Department { get; set; }





    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities
{
    public class DepartmetSubject
    {
        [Key]
        public int DepID { get; set; }
        [Key]
        public int SubId { get; set; }

        [ForeignKey("DepID")]
        public virtual Department? Department { get; set; }
        [ForeignKey("SubId")]
        public virtual Subject? Subject { get; set; }

    }
}

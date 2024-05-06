using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class DepartmetSubject
    {
       
        [Key]
        public int DeptSubID { get; set; }
         public int DepID { get; set; }
        public int SubId { get; set; }

        [ForeignKey("DepID")]
        public virtual Department? Department { get; set; }
        [ForeignKey("SubId")]
        public virtual Subject? Subject { get; set; }

    }
}

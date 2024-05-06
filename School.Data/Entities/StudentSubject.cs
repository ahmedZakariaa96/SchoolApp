using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class StudentSubject
    {
        [Key]
        public int StdSubjID { get; set; }
        public int StudId { get; set; }
        public int SubId { get; set; }

        [ForeignKey("StudId")]
        public virtual Student? Student { get; set; }
        [ForeignKey("SubId")]

        public virtual Subject? Subject { get; set; }


    }
}

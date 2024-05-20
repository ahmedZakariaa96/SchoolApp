using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities
{
    public class StudentSubject
    {
        public int StudId { get; set; }
        public int SubId { get; set; }
        public decimal? grade { get; set; }


        [ForeignKey("StudId")]
        public virtual Student? Student { get; set; }
        [ForeignKey("SubId")]

        public virtual Subject? Subject { get; set; }


    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ganymede_web.Models
{
    public class Horaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Benevole")]
        public int BenevoleID { get; set; }
        public Benevole? Benevole { get; set; } 
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }
        public bool Role { get; set; } 


    }
}

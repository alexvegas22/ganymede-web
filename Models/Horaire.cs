using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
        [DataType(DataType.DateTime)]
        [DisplayName("Date de début")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Date de fin")]
        public DateTime EndTime { get; set; }
        public String Role { get; set; } 


    }
}

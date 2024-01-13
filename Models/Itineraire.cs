using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ganymede_web.Models
{
    public class Itineraire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        [ForeignKey("Horaire")]
        public int HoraireID { get; set; }
        [DisplayName("Horaire Id")]
        public Horaire? Horaire { get; set; }
        [DisplayName("Location de départ")]
        public string? StartLocation { get; set; }
        [DisplayName("Location d'arrivée")]
        public string? EndLocation { get; set; }
    }
}

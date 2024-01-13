using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ganymede_web.Models
{
    public class Itineraire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Horaire")]
        public int HoraireID { get; set; }
        public Horaire? Horaire { get; set; }
        public string? StartLocation { get; set; }
        public string? EndLocation { get; set; }
    }
}

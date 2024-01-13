using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ganymede_web.Models
{
    public class Don
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public int Montant { get; set; }
    }
}

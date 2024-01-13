using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ganymede_web.Models
{
    public class Benevole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nom { get; set; }
        [DisplayName("Mot de passe")]
        public string? Password { get; set; }
        public int Age { get; set; }
        public string? NomEtablissement { get; set; }
        [DisplayName("Voulez-vous faire des tournées?")]
        public bool rolePreferee { get; set; }
        public bool LibreFinDeSemaine { get; set; }
        public bool LibreJourFeries { get; set; }
        public bool RecuFormationPremierSoins { get; set; }



    }
}

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
        [DisplayName("Etes -vous libre la fin de semaine?")]
        public bool LibreFinDeSemaine { get; set; }
        [DisplayName("Etes -vous libre lesjours fériés?")]
        public bool LibreJourFeries { get; set; }
        [DisplayName("Avez vous une certificat de secourisme?")]
        public bool RecuFormationPremierSoins { get; set; }



    }
}

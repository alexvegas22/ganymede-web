﻿using System.ComponentModel.DataAnnotations.Schema;
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
        [DisplayName("Prénom")]
        public string? Password { get; set; }
        public int Age { get; set; }
        public string? NomEtablissement { get; set; }
        public bool rolePreferee { get; set; }
        public bool LibreFinDeSemaine { get; set; }
        public bool LibreJourFeries { get; set; }
        public bool RecuFormationPremierSoins { get; set; }



    }
}

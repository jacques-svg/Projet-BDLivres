using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetBDLivres.Models
{
    public class Utilisateurs
    {
        [Key]
        public int utilisateurId { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [DataType(DataType.Password)]
        public string motDePasse { get; set; }


    }
}

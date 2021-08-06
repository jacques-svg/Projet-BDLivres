using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProjetBDLivres.Models
{
    public class Livres
    {
        [Key]
        public int livreId { get; set; }
        [Required(ErrorMessage = "Le titre est obligatoire")]
        public string titre { get; set; }
       [Required(ErrorMessage = "L'annee de publication est obligatoire")]
        public int annee { get; set; }
        [Required(ErrorMessage = "Le nom de l'auteur est obligatoire")]
        public string auteur { get; set; }
        [DisplayName("Nom Image")]

        public string imageName { get; set; }
        [NotMapped]
        [DisplayName("Ajout Image")]
        public IFormFile ImageFile { get; set; }
    }
}

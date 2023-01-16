using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.ViewModels
{
    public class ClientCreateForm
    {
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [DisplayName("Nom de famille: ")]
        public string nom { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [DisplayName("Prénom: ")]
        public string prenom { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(5)] // a@a.a format accepté
        [EmailAddress]
        [DisplayName("Adresse email: ")]
        public string email {get; set;}

        [Required]
        [MaxLength(32)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe: ")]
        public string pass { get; set; }


        [Required]
        [MaxLength(32)]
        [MinLength(8)]
        [Compare(nameof(pass))]
        [DataType(DataType.Password)]
        [DisplayName("Confirmez le mot de passe: ")]
        public string confirmpass { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(4000)]
        [DisplayName("Adresse: ")]
        public string adresse { get; set; }

    }
}

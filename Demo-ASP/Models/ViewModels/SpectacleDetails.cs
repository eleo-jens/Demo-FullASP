using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.ViewModels
{
    public class SpectacleDetails
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [DisplayName("Nom du spectacle: ")]
        public string nom { get; set; }
        //😉❤️💕

        [DisplayName("Description du spectacle: ")]
        public string description { get; set; }
    }
}

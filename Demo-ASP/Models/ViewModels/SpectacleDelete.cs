using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.ViewModels
{
    public class SpectacleDelete
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [DisplayName("Spectacle: ")]
        public string nom { get; set; }
    }
}

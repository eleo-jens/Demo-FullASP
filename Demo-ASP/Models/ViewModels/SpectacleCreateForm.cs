using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.ViewModels
{
    public class SpectacleCreateForm
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [DisplayName("Spectacle: ")]
        public string nom { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Description (max. 400 caractères): ")]
        public string description { get; set; }
    }
}

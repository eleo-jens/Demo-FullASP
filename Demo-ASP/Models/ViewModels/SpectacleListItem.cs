﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.ViewModels
{
    public class SpectacleListItem
    {
        private string _desc;
        private static int _textLimit = 20;

        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [DisplayName("Nom du spectacle: ")]
        public string nom { get; set; }

        [DisplayName("Description du spectacle: ")]
        public string description {
            get { 
                    if (_desc.Length < _textLimit) 
                        return _desc;
                    return _desc.Substring(0, _textLimit - 3) + "..."; 
                }
            set { _desc = value; }
        }
    }
}

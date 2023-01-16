using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Entities
{
    //Classe POCO
    public class Client
    {
        // ON REPREND TOUTES LES COLONNES DE NOTRE DB
        // DB: INTEGER
        public int id { get; set; }
        // DB: NVARCHAR(255)
        public string email { get; set; }
        // DB: NVARCHAR(32)
        public string pass { get; set; }
        // DB: NVARCHAR(50)
        public string nom { get; set; }
        // DB: NVARCHAR(50)
        public string prenom { get; set; }
        // DB: NVARCHAR(MAX) NULLABLE
        public string adresse { get; set; }
    }
}

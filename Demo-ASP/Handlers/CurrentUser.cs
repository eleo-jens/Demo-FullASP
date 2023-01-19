using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Handlers
{
    // Enregistre les infos de mon utilisateur
    public class CurrentUser
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public DateTime LastConnexion { get; set; }
    }
}

using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Entities
{
    // objet logique: exemple trimer, faire un constructeur 
    public class Spectacle : ISpectacle
    {
        private string _nom; 
        public int id { get; set; }
        public string nom
        {
            get
            { return _nom; }
            set
            {
                _nom = value.Trim();
            }
        }
        public string description { get; set; }

        public Spectacle(int id, string nom, string desc)
        {
            if (string.IsNullOrWhiteSpace(nom)) throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(desc)) throw new ArgumentNullException();
            this.id = id;
            this.nom = nom;
            description = desc; 
        }

        // constructeur si je veux crée un spectacle à partir de l'entité de la DAL
        // :this va d'abord effectué l'action du premier constructeur
        // data transfer object : dto (poco) = entiers de la DAL
        // sera utilisé dans le mapper du BLL: pour transformer de DAL à BLL et vice versa
        public Spectacle(Demo_DAL.Entities.Spectacle dto):this(dto.id, dto.nom, dto.description)
        {

        }
    }
}

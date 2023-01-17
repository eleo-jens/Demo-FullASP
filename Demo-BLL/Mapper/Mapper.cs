using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = Demo_DAL.Entities;
using BLL = Demo_BLL.Entities;

namespace Demo_BLL
{
    static class Mapper
    {

        #region MAPPER CLIENT
        // transforme le client DAL en client BLL
        public static BLL.Client ToBLL(this DAL.Client entity)
        {
            if (entity is null) return null;
            return new BLL.Client()
            {
                id = entity.id,
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.pass
            };
        }

        // transforme le client BLL en client DAL
        public static DAL.Client ToDAL(this BLL.Client entity)
        {
            if (entity is null) return null;
            return new DAL.Client()
            {
                id = entity.id,
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.pass
            };
        }
        #endregion

        #region MAPPER SPECTACLE
        // retourne un objet du BLL
        public static BLL.Spectacle ToBLL(this DAL.Spectacle entity)
        {
            if (entity is null) return null;
            // 1er constructeur à 3 paramètres
            //return new BLL.Spectacle(
            //    id = entity.id,
            //    nom = entity.nom,
            //    description = entity.description
            //);

            // 2e constructeur qu'on a construit pour les spectacles de la DAL
            return new BLL.Spectacle(entity);
        }

        // transforme le client BLL en client DAL : l'objet de la dal ne peut pas avoir de constructeur que celui par défaut car objet POCO du coup pour les objets du BLL on essaye de suivre le meme schema avec le constructeur par défaut
        public static DAL.Spectacle ToDAL(this BLL.Spectacle entity)
        {
            if (entity is null) return null;
            return new DAL.Spectacle()
            {
                id = entity.id,
                nom = entity.nom,
                description = entity.description
            };
        } 
        #endregion


    }
}

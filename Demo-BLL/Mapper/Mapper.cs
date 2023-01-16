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

    }
}

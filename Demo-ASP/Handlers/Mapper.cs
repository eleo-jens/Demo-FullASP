using Demo_ASP.Models.ViewModels;
using Demo_BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Handlers
{
    public static class Mapper
    {
        public static ClientListItem ToListItem(this Demo_BLL.Entities.Client entity)
        {
            if (entity is null) return null;
            return new ClientListItem()
            {
                id = entity.id,
                nom = entity.nom,
                prenom = entity.prenom
            }; 
        }
        public static Demo_BLL.Entities.Client ToBLL(this ClientCreateForm entity)
        {
            if (entity is null) return null;
            return new Client()
            {
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.pass
            };
        }

        public static SpectacleListItem ToListItem(this Demo_BLL.Entities.Spectacle entity)
        {
            if (entity is null) return null;
            return new SpectacleListItem()
            {
                id = entity.id,
                nom = entity.nom,
                description = entity.description
            };
        }
    }
}

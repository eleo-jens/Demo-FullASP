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
        #region Mapper Client
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
        #endregion

        #region Mapper Spectacle
        public static SpectacleListItem ToListItem(this Demo_BLL.Entities.Spectacle entity)
        {
            if (entity is null) return null;
            // On aurait pu créer un constructeur dans nos modèles de vues (mais bonne pratique: juste avoir les champs et les attributs de validation)
            return new SpectacleListItem()
            {
                id = entity.id,
                nom = entity.nom,
                description = entity.description
            };
        }

        public static SpectacleDetails ToDetails(this Spectacle entity)
        {
            if (entity is null) return null;
            return new SpectacleDetails()
            {
                id = entity.id,
                nom = entity.nom,
                description = entity.description
            };
        }

        public static SpectacleDelete ToDelete(this Spectacle entity)
        {
            if (entity is null) return null;
            return new SpectacleDelete()
            {
                id = entity.id,
                nom = entity.nom
            };
        }

        public static SpectacleEditForm ToEdit(this Spectacle entity)
        {
            if (entity is null) return null;
            return new SpectacleEditForm()
            {
                nom = entity.nom, 
                description = entity.description
            };
        }

        public static Spectacle ToBLL(this SpectacleCreateForm entity)
        {
            if (entity is null) return null;
            // je ne récupère pas l'identifiant de mon formulaire car il n'y en a pas 
            return new Spectacle(default(int), entity.nom, entity.description);
        }

        public static Spectacle ToBLL(this SpectacleEditForm entity)
        {
            if (entity is null) return null;
            // je ne récupère pas l'identifiant de mon formulaire car il n'y en a pas 
            return new Spectacle(default(int), entity.nom, entity.description);
        }
        #endregion
    }
}

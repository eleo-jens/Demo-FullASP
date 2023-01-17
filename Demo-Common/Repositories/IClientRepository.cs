using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    // pour ajouter une méthode supplémentaire 
    // en tant que IRepository fera les fonctionnalités du CRUD plus la méthode CheckPassword
    public interface IClientRepository<TEntity, TId> :IRepository<TEntity, TId> where TEntity : IClient
    {
        int? CheckPassword(string email, string password); 
    }
}

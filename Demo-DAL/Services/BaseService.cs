using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    public abstract class BaseService
    {
        // injection de dépendance pour la configuration
        protected readonly string _connectionString;

        // on passe le nom de la DB en parametre si jamais on travaille avec plusieurs DB 
        public BaseService(IConfiguration config, string dbName)
        {
            _connectionString = config.GetConnectionString(dbName);
        }
    }
}

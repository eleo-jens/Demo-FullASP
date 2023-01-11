﻿using Demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL
{
    // une seule class dans 
    static class Mapper
    {
        public static Client toClient (this IDataRecord record)
        {
            if (record is null) return null;
            return new Client()
            {
                id = (int)record[nameof(Client.id)],
                nom = (string)record[nameof(Client.nom)],
                prenom = (string)record[nameof(Client.prenom)],
                email = (string)record[nameof(Client.email)],
                pass = "********",
                adresse = (record[nameof(Client.adresse)] is DBNull) ? null : (string)record[nameof(Client.adresse)]
            };
        }
    }
}

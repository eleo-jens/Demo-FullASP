using Demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    // fournir les fonctionnalités qui contacteront la DB, c'est lui qui fait l'ADO
    // pour obtenir le client: transforme les données SQL en client, le service appel le mapper 
    class ClientService
    {
        private string ConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Theatre - DB; Integrated Security = True";
        public IEnumerable<Client> Get()
        {
            using (SqlConnection connection= new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [id], [nom], [prenom], [email], [pass], [adresse] FROM [Client]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Mapper.toClient(reader);
                        }
                    }
                }
            }
        }

        public Client Get(int id)
        {
            return null;
        }

        // on recuper l'id car il est aurtogénéré comme ça on le connait
        public int Insert(Client entity)
        {
            return 0;
        }

        // on récupére l'id du client de la DB à modifier, on récupère l'entity Client (celui avec les nouvelles
        // infos provenant de l'application)
        public bool Update(int id, Client entity)
        {
            return false; 
        }

        public bool Delete(int id)
        {
            return false; 
        }
    }
}

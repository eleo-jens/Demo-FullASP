using Demo_Common.Repositories;
using Demo_DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    // fournir les fonctionnalités qui contacteront la DB, c'est lui qui fait l'ADO
    // pour obtenir le client: transforme les données SQL en client, le service appel le mapper 
    public class ClientService : BaseService, IClientRepository<Client, int>
    {
        public ClientService(IConfiguration config): base(config, "Theatre-DB")
        {
        }

        public IEnumerable<Client> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT [id], [nom], [prenom], [email], [pass], [adresse] FROM [Client]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToClient();
                        }
                    }
                }
            }
        }

        public Client Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT [id], [nom], [prenom], [email], [pass], [adresse] 
                                            FROM [Client] WHERE [id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open(); 
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToClient();
                        return null;
                    }
                }
            }
        }

        // on recuper l'id car il est aurtogénéré comme ça on le connait
        public int Insert(Client entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //command.CommandText = @"INSERT INTO [Client] ([nom],[prenom], [email], [pass], [adresse]) OUTPUT [inserted].[id] VALUES(@nom, @prenom, @email, @pass, @adresse)";
                    command.CommandText = "SP_ClientAdd";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("nom", entity.nom);
                    command.Parameters.AddWithValue("prenom", entity.prenom);
                    command.Parameters.AddWithValue("email", entity.email);
                    command.Parameters.AddWithValue("pass", entity.pass);
                    command.Parameters.AddWithValue("adresse", entity.adresse);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        // on récupére l'id du client de la DB à modifier, on récupère l'entity Client (celui avec les nouvelles
        // infos provenant de l'application)
        public bool Update(int id, Client entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE [Client]
                                            SET [nom] = @nom, 
                                                [prenom] = @prenom,
                                                [email] = @email,
                                                [adresse] = @adresse
                                            WHERE [id] = @id";
                    command.Parameters.AddWithValue("nom", entity.nom);
                    command.Parameters.AddWithValue("prenom", entity.prenom);
                    command.Parameters.AddWithValue("email", entity.email);
                    command.Parameters.AddWithValue("adresse", entity.adresse);
                    command.Parameters.AddWithValue("id", entity.id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM [Client]
                                            WHERE [id] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public int? CheckPassword(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_ClientCheck";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("email", email);
                    command.Parameters.AddWithValue("pass", password);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return (result is DBNull)? null : (int?) result;
                }
            }
        }
    }
}

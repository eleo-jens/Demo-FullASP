using Demo_Common.Repositories;
using Demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    public class SpectacleService : ISpectacleRepository<Spectacle, int>
    {
        private string ConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Theatre-DB;Integrated Security=True";
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Spectacle> Get()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT [id], [nom], [description] FROM [spectacle]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToSpectacle();
                        }
                    }
                }
            }
        }

        public Spectacle Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Spectacle entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Spectacle entity)
        {
            throw new NotImplementedException();
        }
    }
}

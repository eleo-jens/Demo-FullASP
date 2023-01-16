using Demo_Common.Repositories;
using Demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    class SpectacleService : IRepository<Spectacle, int>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Spectacle> Get()
        {
            throw new NotImplementedException();
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

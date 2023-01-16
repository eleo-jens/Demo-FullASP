using Demo_BLL.Entities;
using Demo_Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Services
{
    public class ClientService: IClientRepository<Client, int>
    {
        // on va instancier le ClientService de la DAL dans le ClientService du BLL
        private readonly IClientRepository<Demo_DAL.Entities.Client, int> _repository;
        // faire un constructeur du clientservice
        public ClientService(IClientRepository<Demo_DAL.Entities.Client, int> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Client> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Client Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(Client entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(int id, Client entity)
        {
            return _repository.Update(id, entity.ToDAL());
        }

        public bool Delete(int id)
        {
            //pas de conversion donc pas besoin de passer par le mapper
            return _repository.Delete(id);

        }

        public int? CheckPassword(string email, string password)
        {
            return _repository.CheckPassword(email, password);
        }
    }
}

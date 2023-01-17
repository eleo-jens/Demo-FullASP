using Demo_BLL.Entities;
using Demo_Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Services
{
    public class SpectacleService : ISpectacleRepository<Spectacle, int>
    {

        // on doit connaitre le repository de la DAL pour accéder aux méthodes CRUD : on doit connaitre l'interface en créant un champ privé
        private readonly ISpectacleRepository<Demo_DAL.Entities.Spectacle, int> _repository;

        // on instancie l'interface via un constructeur 
        // dans les parenthèses: je demande à l'app de chercher une instance, il me fournit la zone mémoire de l'instance soit il crée une nouvelle instance via services.AppScoped 
        // Le BLL va récupérer une instance de la DAL
        public SpectacleService(ISpectacleRepository<Demo_DAL.Entities.Spectacle, int> repository)
        {
            // liaison entre le champ et l'instance qu'on va me fournir
            _repository = repository;
        }

        public IEnumerable<Spectacle> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Spectacle Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(Spectacle entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(int id, Spectacle entity)
        {
            return _repository.Update(id, entity.ToDAL());
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}

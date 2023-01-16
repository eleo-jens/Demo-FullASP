using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface IRepository<TEntity, TId>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TId id);
        TId Insert(TEntity entity);
        bool Update(TId id, TEntity entity);
        bool Delete(TId id);
    }
}

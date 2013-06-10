using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MPM.Infra.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity item);

        TEntity Modify(TEntity item);

        void Remove(TEntity item);

        TEntity Get(Guid key);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MPM.Infra.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Insert(TEntity entity);
        void Edit(TEntity entity);
        void Delete(Guid id);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);
    }
}

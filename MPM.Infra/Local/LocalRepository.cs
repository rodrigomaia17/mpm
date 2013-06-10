using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MPM.Dominio.Interfaces;
using MPM.Infra.Interfaces;

namespace MPM.Infra.Local
{
    internal abstract class LocalRepository<TEntity> : IRepository<TEntity> where TEntity : IPossuiGuidId
    {
        protected static readonly Dictionary<Guid, TEntity> _colecao = new Dictionary<Guid, TEntity>();


        public void Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _colecao.Add(entity.Id, entity);
        }

        public void Delete(Guid id)
        {
            _colecao.Remove(id);
        }
        public void Edit(TEntity entity)
        {
            _colecao[entity.Id] = entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _colecao.Values.AsQueryable();
        }

        public TEntity GetById(Guid id)
        {
            return _colecao[id];
        }

        public IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter)
        {
            return _colecao.Values.Where(filter.Compile());
        }

      
      
    }
}

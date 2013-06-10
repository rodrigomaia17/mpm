using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MPM.Dominio;
using MPM.Infra.Interfaces;

namespace MPM.Infra.Local
{
    internal class LocalUsuarioRepository : IUsuarioRepository
    {
        public Usuario Add(Usuario item)
        {
            throw new NotImplementedException();
        }

        public Usuario Modify(Usuario item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario item)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(Guid key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetFiltered(Expression<Func<Usuario, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}

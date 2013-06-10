using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPM.Infra.Factory;
using MPM.Infra.Interfaces;

namespace MPM.Infra.Local
{
    public class LocalRepositoryFactory : IRepositoryFactory
    {
        private IUsuarioRepository _usuarioRepository;

        public IUsuarioRepository GetUsuarioRepository()
        {
            return _usuarioRepository ?? (_usuarioRepository = new LocalUsuarioRepository());
        }

       
    }
}

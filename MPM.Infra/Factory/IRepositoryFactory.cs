using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPM.Infra.Interfaces;

namespace MPM.Infra.Factory
{
    public interface IRepositoryFactory
    {
        IUsuarioRepository GetUsuarioRepository();
    }
}

using System;
using System.Collections.Generic;
using MPM.Dominio.Interfaces;

namespace MPM.Dominio
{
    public class Usuario : IPossuiGuidId
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public IList<Veiculo> Veiculos { get; set; }

        public string Email { get; set; }
    }
}

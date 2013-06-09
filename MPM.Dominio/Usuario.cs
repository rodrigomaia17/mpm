using System;
using System.Collections.Generic;

namespace MPM.Dominio
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IList<Veiculo> Veiculos { get; set; } 
    }
}

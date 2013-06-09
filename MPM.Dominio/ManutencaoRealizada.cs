using System;

namespace MPM.Dominio
{
    public class ManutencaoRealizada
    {
        public TipoManutencao Tipo { get; set; }
        public DateTime Data { get; set; }
        public int Kilometragem { get; set; }
    }
}

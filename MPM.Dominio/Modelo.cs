using System;
using System.Collections.Generic;

namespace MPM.Dominio
{
    public class Modelo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<ManutencaoRecomendada> ManutencoesRecomendadas { get; set; }

        public Modelo()
        {
            ManutencoesRecomendadas = new List<ManutencaoRecomendada>();
        }
    }
}

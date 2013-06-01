using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

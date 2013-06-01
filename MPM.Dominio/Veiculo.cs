using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPM.Dominio
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Modelo Modelo { get; set; }
        public int Kilometragem { get; set; }
        public IEnumerable<ManutencaoRealizada> ManutencoesRealizadas { get; private set; }

        public Veiculo()
        {
            ManutencoesRealizadas = new List<ManutencaoRealizada>();
        }

        public IEnumerable<ManutencaoPendente> VerificaManutencoesPendentes()
        {
            var retorno = new List<ManutencaoPendente>();

            foreach (var manuRecomendada in Modelo.ManutencoesRecomendadas)
            {
                if(!ManutencoesRealizadas.Any(m => m.Tipo.Equals(manuRecomendada.Tipo)))
                    retorno.Add(new ManutencaoPendente(manuRecomendada.Tipo, Kilometragem - manuRecomendada.Intervalo));
            }

            return retorno;
        }
 
    }
}

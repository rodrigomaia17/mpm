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
        public IList<ManutencaoRealizada> ManutencoesRealizadas { get; private set; }

        public Veiculo()
        {
            ManutencoesRealizadas = new List<ManutencaoRealizada>();
        }

        public IEnumerable<ManutencaoPendente> VerificaManutencoesPendentes()
        {
            var retorno = new List<ManutencaoPendente>();

            foreach (var manuRecomendada in Modelo.ManutencoesRecomendadas)
            {
                var ultimaManutencao =
                    ManutencoesRealizadas.OrderByDescending(p => p.Data)
                                         .FirstOrDefault(realizada => realizada.Tipo == manuRecomendada.Tipo);

                if(ultimaManutencao == null && Kilometragem > manuRecomendada.Intervalo)
                    retorno.Add(new ManutencaoPendente(manuRecomendada.Tipo, Kilometragem - manuRecomendada.Intervalo));
                else if(ultimaManutencao != null && ((Kilometragem - ultimaManutencao.Kilometragem) > manuRecomendada.Intervalo))
                    retorno.Add(new ManutencaoPendente(manuRecomendada.Tipo, Kilometragem - ultimaManutencao.Kilometragem));

            }

            return retorno;
        }
 
    }
}

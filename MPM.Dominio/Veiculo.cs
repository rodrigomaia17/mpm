using System;
using System.Collections.Generic;
using System.Linq;

namespace MPM.Dominio
{
    public class Veiculo
    {
        private int _kilometragem { get; set; }
        private List<ManutencaoRealizada> manutencoesRealizadas { get; set; } 

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Modelo Modelo { get; set; }
        public int Kilometragem
        {
            get
            {
                return _kilometragem;
            }
            set
            {
                _kilometragem = value;
                VerificaManutencoesPendentes();
            }
        }
        public IEnumerable<ManutencaoRealizada> ManutencoesRealizadas { get { return manutencoesRealizadas; } private set { manutencoesRealizadas = (List<ManutencaoRealizada>) value; } }
        public IEnumerable<ManutencaoPendente> ManutencoesPendentes { get; private set; }

        public Veiculo()
        {
            manutencoesRealizadas = new List<ManutencaoRealizada>();
            ManutencoesPendentes = new List<ManutencaoPendente>();
        }

        public void AdicionarManutencaoRealizada(ManutencaoRealizada manutencao)
        {
            manutencoesRealizadas.Add(manutencao);
            VerificaManutencoesPendentes();
        }

        private void VerificaManutencoesPendentes()
        {
            var retorno = new List<ManutencaoPendente>();

            foreach (var manuRecomendada in Modelo.ManutencoesRecomendadas)
            {
                var ultimaManutencao =
                    ManutencoesRealizadas.OrderByDescending(p => p.Data)
                                         .FirstOrDefault(realizada => realizada.Tipo == manuRecomendada.Tipo);

                if (ultimaManutencao == null && Kilometragem > manuRecomendada.Intervalo)
                    retorno.Add(new ManutencaoPendente(manuRecomendada.Tipo, Kilometragem - manuRecomendada.Intervalo));
                else if (ultimaManutencao != null && ((Kilometragem - ultimaManutencao.Kilometragem) > manuRecomendada.Intervalo))
                    retorno.Add(new ManutencaoPendente(manuRecomendada.Tipo, Kilometragem - ultimaManutencao.Kilometragem));

            }

            ManutencoesPendentes = retorno;
        }

    }
}

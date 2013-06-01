
namespace MPM.Dominio
{
    public class ManutencaoPendente
    {
        public TipoManutencao Tipo { get; set; }
        public int KilometrosDeAtraso { get; set; }

        public ManutencaoPendente(TipoManutencao tipo, int kilometrosDeAtrasos)
        {
            Tipo = tipo;
            KilometrosDeAtraso = kilometrosDeAtrasos;
        }
        
    }
}

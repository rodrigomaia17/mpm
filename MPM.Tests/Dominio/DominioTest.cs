using System;
using System.Collections.Generic;
using System.Linq;
using MPM.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MPM.Tests.Dominio
{
    [TestClass]
    public class DominioTest
    {
        [TestMethod]
        public void ConsigoDetectarManutencaoNuncaRealizada()
        {

            var modelo = new Modelo()
            {
                Nome = "FordKa",
                ManutencoesRecomendadas = new List<ManutencaoRecomendada>()
                        {
                            new ManutencaoRecomendada() { Intervalo = 10000, Tipo = TipoManutencao.TrocaDeOleo }
                        }
            };

            var veiculo = new Veiculo() { Modelo = modelo, Kilometragem = 30000 };

            var pendencias = veiculo.VerificaManutencoesPendentes().ToList();

            Assert.IsTrue(pendencias.Count == 1);
            Assert.IsTrue(pendencias.Single().Tipo == TipoManutencao.TrocaDeOleo);
            Assert.IsTrue(pendencias.Single().KilometrosDeAtraso == 20000);



        }
    }
}

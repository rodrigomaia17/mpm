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

            var modelo = EntidadesUtil.NovoModelo();

            var veiculo = new Veiculo() { Modelo = modelo, Kilometragem = 30000 };

            var pendencias = veiculo.VerificaManutencoesPendentes().ToList();

            Assert.IsTrue(pendencias.Count == 1);
            Assert.IsTrue(pendencias.Single().Tipo == TipoManutencao.TrocaDeOleo);
            Assert.IsTrue(pendencias.Single().KilometrosDeAtraso == 20000);

        }

        [TestMethod]
        public void ConsigoDetectarManutencaoJaRealizadaNovamente()
        {
            var modelo = EntidadesUtil.NovoModelo();

            var veiculo = new Veiculo() { Modelo = modelo, Kilometragem = 30000 };
            veiculo.ManutencoesRealizadas.Add(new ManutencaoRealizada()
                {
                    Data = DateTime.Today,
                    Kilometragem = 15000,
                    Tipo = TipoManutencao.TrocaDeOleo
                });

            var pendencias = veiculo.VerificaManutencoesPendentes().ToList();

            Assert.IsTrue(pendencias.Count == 1);
            Assert.IsTrue(pendencias.Single().Tipo == TipoManutencao.TrocaDeOleo);
            Assert.IsTrue(pendencias.Single().KilometrosDeAtraso == 15000);
        }
    }

    public static class EntidadesUtil
    {
        public static Modelo NovoModelo()
        {
            var modelo = new Modelo()
            {
                Nome = "FordKa",
                ManutencoesRecomendadas = new List<ManutencaoRecomendada>()
                        {
                            new ManutencaoRecomendada() { Intervalo = 10000, Tipo = TipoManutencao.TrocaDeOleo }
                        }
            };

            return modelo;
        }
    }
}

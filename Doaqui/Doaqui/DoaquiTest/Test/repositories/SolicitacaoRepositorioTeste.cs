using Doaqui.src.data;
using Doaqui.src.repositories.implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;

namespace DoaquiTeste.Test.repositories
{
    [TestClass]
    public class SolicitacaoRepositorioTeste
    {

        private DoaquiContexto _contexto;
        private SolicitacaoRepositorio _repositorio;

        [TestMethod]
        public void CriarUmaSolicitacaoRetornaUmaSolicitacao()
        {
            var opt = new DbContextOptionsBuilder<DoaquiContexto>()
            .UseInMemoryDatabase(databaseName: "db_doaqui")
            .Options;

            _contexto = new DoaquiContexto(opt);
            _repositorio = new SolicitacaoRepositorio(_contexto);

            _repositorio.NovaSolicitacao(
                new NovaSolicitacaoDTO(new UsuarioModelo(), new DoacaoModelo()));

            List<SolicitacaoModelo> solicitacaoModelos = _repositorio.PegarTodasSolicitacoes();
            Assert.AreEqual(1, solicitacaoModelos.Count);
        }

    }
}

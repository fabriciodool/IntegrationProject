using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doaqui.src.data;
using Doaqui.src.repositories.implementations;
using Microsoft.EntityFrameworkCore;
using Doaqui.src.dtos;
using System.Linq;
using System.Collections.Generic;
using Doaqui.src.models;

namespace DoaquiTeste.Test.repositories
{

    [TestClass]
    public class DoacaoRepositorioTeste
    {

        private DoaquiContexto _contexto;
        private DoacaoRepositorio _repositorio;

        [TestMethod]
        public void CriarUmaDoacaoRetornaUmaDoacao()
        {
            var opt = new DbContextOptionsBuilder<DoaquiContexto>()
            .UseInMemoryDatabase(databaseName: "db_doaqui")
            .Options;

            _contexto = new DoaquiContexto(opt);
            _repositorio = new DoacaoRepositorio(_contexto);

            _repositorio.NovaDoacao(new NovaDoacaoDTO("11912345678", 2, "12/12/2022", "DescricaoTeste", 1234567891));

            List<DoacaoModelo> doacaoModelos = _repositorio.PegarTodasDoacoes();
            Assert.AreEqual(1, doacaoModelos.Count);
        }

    }


}

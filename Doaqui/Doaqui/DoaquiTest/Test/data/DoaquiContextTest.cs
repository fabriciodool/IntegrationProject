using Microsoft.EntityFrameworkCore;
using Doaqui.src.data;
using Doaqui.src.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DoaquiTest.Test.data
{
    [TestClass]
    public class DoaquiContextTest
    {
        private DoaquiContext _context;
        
        [TestInitialize]
        public void Inicio()
        {
            DbContextOptions<DoaquiContext> opt = new DbContextOptionsBuilder<DoaquiContext>()
            .UseInMemoryDatabase(databaseName: "db_doaqui")
            .Options;

            _context = new DoaquiContext(opt);
        }

        [TestMethod]
        public void InsertNewUserReturnsUser()
        {
            UsuarioModel model = new UsuarioModel();
            model.CNPJ_ONG = 000000000;
            model.Nome = "TestName";
            model.Email = "TestEmail";
            model.Telefone = "TestPhone";
            model.Endereco = "TestAddress";
            model.Senha = "TestPassword";
            _context.Usuarios.Add(model);
            _context.SaveChanges();
            Assert.IsNotNull(_context.Usuarios.FirstOrDefault(u => u.Senha == "TestPassword"));
        }

        [TestMethod]
        public void InsertNewRequestReturnsRequest()
        {
            SolicitacaoModel model = new SolicitacaoModel();
            model.Id = 0;
            model.ONG = null;
            model.Doacao = null;
            _context.Solicitacoes.Add(model);
            _context.SaveChanges();
            Assert.IsNotNull(_context.Solicitacoes.FirstOrDefault(r => r.Doacao == null));
        }

        [TestMethod]
        public void InsertNewDonationReturnsDonation()
        {
            DoacaoModel model = new DoacaoModel();
            model.Contato = "TestContact";
            model.Quantidade = 10000;
            model.Validade = "TestValidity";
            model.Descricao = "TestDescription";
            model.CNPJ_Doador = 000000000;
            _context.Doacoes.Add(model);
            _context.SaveChanges();
            Assert.IsNotNull(_context.Doacoes.FirstOrDefault(d => d.Id == 1));
        }
    }
}

      
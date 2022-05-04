using Doaqui.src.data;
using Doaqui.src.modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogPessoalTest.Testes.data
{
    [TestClass]
    public class DoaquiContextTest
    {
        private DoaquiContext _context;
        [TestInitialize]
        public void inicio()
        {
            var opt = new DbContextOptionsBuilder<DoaquiContext>()
                .UseInMemoryDatabase(databaseName: "db_Doaqui")
                .Options;
            _context = new DoaquiContext(opt);
        }
    }
}
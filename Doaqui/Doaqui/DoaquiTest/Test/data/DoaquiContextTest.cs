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
            var opt = new DbContextOptionsBuilder<DoaquiContext>()
            .UseInMemoryDatabase(databaseName: "db_doaqui")
            .Options;

            _context = new DoaquiContext(opt);
        }
    }
}

      
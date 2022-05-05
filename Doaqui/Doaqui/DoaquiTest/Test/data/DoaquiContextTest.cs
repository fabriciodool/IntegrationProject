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
        private DoaquiContext _contexto;
        
        [TestInitialize]
        public void inicio()
        {
            var opt = new DbContextOptionsBuilder<DoaquiContext>()
            .UseInMemoryDatabase(databaseName: "db_doaqui")
            .Options;

            _contexto = new DoaquiContext(opt);
        }
    }
}

      
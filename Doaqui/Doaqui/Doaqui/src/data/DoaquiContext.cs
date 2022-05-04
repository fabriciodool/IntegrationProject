using Doaqui.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace Doaqui.src.data
{
    public class DoaquiContext : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<DoacaoModel> Temas { get; set; }
        public DbSet<VendaModel> Postagens { get; set; }

        public DoaquiContext(DbContextOptions<DoaquiContext> opt) : base(opt)
        {

        }
    }
}
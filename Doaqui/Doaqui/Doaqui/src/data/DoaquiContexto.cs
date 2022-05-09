using Doaqui.src.models;
using Microsoft.EntityFrameworkCore;

namespace Doaqui.src.data
{
    public class DoaquiContexto : DbContext
    {
        public DbSet<UsuarioModelo> Usuarios { get; set; }
        public DbSet<DoacaoModelo> Doacoes { get; set; }
        public DbSet<SolicitacaoModelo> Solicitacoes { get; set; }

        public DoaquiContexto(DbContextOptions<DoaquiContexto> opt) : base(opt)
        {

        }
    }
}
using Doaqui.src.models;
using Microsoft.EntityFrameworkCore;

namespace Doaqui.src.data
{
    public class DoaquiContext : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<DoacaoModel> Doacoes { get; set; }
        public DbSet<SolicitacaoModel> Solicitacoes { get; set; }

        public DoaquiContext(DbContextOptions<DoaquiContext> opt) : base(opt)
        {

        }
    }
}
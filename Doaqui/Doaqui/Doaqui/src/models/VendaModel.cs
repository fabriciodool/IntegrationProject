using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doaqui.src.models
{
    [Table("tb_venda")]
    public class VendaModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("fk_usuario")]
        public UsuarioModel ONG { get; set; }

        [ForeignKey("fk_doacao")]
        public DoacaoModel Doacao { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doaqui.src.models
{
    [Table("tb_Solicitacao")]
    public class SolicitacaoModelo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("fk_usuario")]
        public UsuarioModelo ONG { get; set; }

        [ForeignKey("fk_doacao")]
        public DoacaoModelo Doacao { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Doaqui.src.models
{
    [Table("tb_Usuarios")]
    public class UsuarioModelo
    {

        [Key]
        public int CNPJ_ONG { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(14)]
        public string Telefone { get; set; }

        [Required, StringLength(50)]
        public string Endereco { get; set; }

        [Required, StringLength(20)]
        public string Senha { get; set; }  
    }
}

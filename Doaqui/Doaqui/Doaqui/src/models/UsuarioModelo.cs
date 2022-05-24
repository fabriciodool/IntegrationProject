using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Doaqui.src.utilidades;

namespace Doaqui.src.models
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_usuarios no banco.</para>
    /// <para>Criado por: Naomy Santana</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/05/2022</para>
    /// </summary>
    
    [Table("tb_Usuarios")]
    public class UsuarioModelo
    {

        [Key]
        public int Id { get; set; }

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

        [Required]
        public TipoUsuario Tipo { get; set; }

        [Required]
        public int Cnpj { get; set; }
    }
}

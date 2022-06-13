using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Doaqui.src.models
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_doacao no banco.</para>
    /// <para>Criado por: Naomy Santana</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/05/2022</para>
    /// </summary>
    
    [Table("tb_Doacao")]
    public class DoacaoModelo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Contato { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required, StringLength(10)]
        public string Validade { get; set; }

        [Required, StringLength(200)]
        public string Descricao { get; set; }

        [Required, StringLength(14)]
        public string CNPJ_Doador { get; set; }

        [Required, StringLength(50)]

        public string Titulo { get; set; }

        [Required, StringLength(500)]
        public string Foto { get; set; }
          
    }
}
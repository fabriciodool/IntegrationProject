using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Doaqui.src.models
{
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
        public int CNPJ_Doador { get; set; }
          
    }
}
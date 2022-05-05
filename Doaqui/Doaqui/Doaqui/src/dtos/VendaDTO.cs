using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;


namespace Doaqui.src.dtos
{ 
      /// <summary>
    /// <para>Resumo: Classe espelho para criar um nova venda</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 05/05/2022</para>
    /// </summary>

    public class NovaVendaDTO
    {
        [Required, StringLength(20)]
        public string Descricao { get; set; }
        public NovaVendaDTO(string descricao)
        {
            Descricao = descricao;
        }
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para alterar uma venda </para>
    /// <para>Criado por: Renata nues</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 05/04/2022</para>
    /// </summary>
    public class AtualizarVendaDTO
    { 
        [Required]

        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Descricao { get; set; }
        public AtualizarVendaDTO(string descricao)
     
        {
            Descricao = descricao;
        }
    }
}

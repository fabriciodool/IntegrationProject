using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;


namespace Doaqui.src.dtos
{ 
    /// <summary>
    /// <para>Resumo: Classe espelho para criar um nova solicitação</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 2.0</para>
    /// <para>Data: 05/05/2022</para>
    /// </summary>

    public class NovaSolicitacaoDTO
    {
        [Required, StringLength(20)]
        public string Descricao { get; set; }

        public NovaSolicitacaoDTO(string descricao)
        {
            Descricao = descricao;
        }
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para alterar uma solicitacao </para>
    /// <para>Criado por: Renata nues</para>
    /// <para>Versão: 2.0</para>
    /// <para>Data: 05/04/2022</para>
    /// </summary>
    public class AtualizarSolicitacaoDTO
    { 
        [Required]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Descricao { get; set; }

        public AtualizarSolicitacaoDTO(string descricao)
        {
            Descricao = descricao;
        }
    }
}

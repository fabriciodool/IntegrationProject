using Doaqui.src.models;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;


namespace Doaqui.src.dtos
{ 
    /// <summary>
    /// <para>Resumo: Classe espelho para criar um nova solicitação</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 3.0</para>
    /// <para>Data: 05/05/2022</para>
    /// </summary>

    public class NovaSolicitacaoDTO
    {
        public NovaSolicitacaoDTO(UsuarioModelo ong, DoacaoModelo doacao)
        {
            ONG = ong;
            Doacao = doacao;
        }

        [Required]
        public UsuarioModelo ONG { get; set; }

        [Required]
        public DoacaoModelo Doacao { get; set; }
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para alterar uma solicitacao </para>
    /// <para>Criado por: Renata nues</para>
    /// <para>Versão: 3.0</para>
    /// <para>Data: 05/05/2022</para>
    /// </summary>
    public class AtualizarSolicitacaoDTO
    {
        public AtualizarSolicitacaoDTO(int cnpj, UsuarioModelo ong, DoacaoModelo doacao)
        {
            Cnpj = cnpj;
            ONG = ong;
            Doacao = doacao;
        }

        [Required]
        public int Cnpj { get; set; }

        [Required]
        public UsuarioModelo ONG { get; set; }

        [Required]
        public DoacaoModelo Doacao { get; set; }
    }
}

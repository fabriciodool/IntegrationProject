using System.ComponentModel.DataAnnotations; 

namespace Doaqui.src.dtos
{ 
    /// <summary>
    /// <para>Resumo: Classe espelho para cria nova postagem de doação</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 2.0</para>
    /// <para>Data: 05/05/2022</para>
    /// </summary>
    public class NovaDoacaoDTO
    {
        [Required, StringLength(100)]
        
        public string Contato{ get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required, StringLength(30)]
        public string Validade  { get; set; }

        [Required, StringLength(100)]
        public string DescricaoDoacao { get; set; }
        
        [Required, StringLength(14)]
        public string CNPJ_Doador { get; set; }
        
        [Required, StringLength(50)]
        public string Titulo { get; set; }

        public NovaDoacaoDTO(string contato, int quantidade, string validade, string descricaoDoacao, string cnpj_doador, string titulo)
        {
            Contato = contato;
            Quantidade = quantidade;
            Validade = validade;
            DescricaoDoacao = descricaoDoacao;
            CNPJ_Doador = cnpj_doador;
            Titulo = titulo;
        }
        
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para alterar uma doacao</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 2.0</para>
    /// <para>Data: 05/05/2022</para>
    /// </summary>
    public class AtualizarDoacaoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CNPJ_Doador { get; }

        [Required, StringLength(100)]
        public string Contato{ get; set; }
       
        [Required]
        public int Quantidade { get; set; }

        [Required, StringLength(30)]
        public string Validade  { get; set; }

        [Required, StringLength(200)]
        public string DescricaoDoacao { get; set; }

        [Required, StringLength(50)]

        public string Titulo { get; set; }

        public AtualizarDoacaoDTO(int id, string cNPJ_Doador, string contato, int quantidade, string validade, string descricaoDoacao, string titulo)
        {
            Id = id;
            Titulo = titulo;
            CNPJ_Doador = cNPJ_Doador;
            Contato = contato;
            Quantidade = quantidade;
            Validade = validade;
            DescricaoDoacao = descricaoDoacao;
        }
        
    }
}

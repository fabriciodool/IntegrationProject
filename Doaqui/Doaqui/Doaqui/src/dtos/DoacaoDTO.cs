using System.ComponentModel.DataAnnotations; 

namespace Doaqui.src.modelos
{ 
 /// <summary>
    /// <para>Resumo: Classe espelho para cria nova postagem</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 05/05/2022</para>
    /// </summary>
    public class NovaDoacaoDTO
    {
       
        [Required, StringLength(30)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Contato{ get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required, StringLength(30)]
        public string Validade  { get; set; }

        [Required]
        public string DescricaoVenda { get; set; }

        public NovaDoacaoDTO(int id, string contato, int quantidade, string validade, string descricaovenda)
        {
            Id = id;
            Contato = contato;
            Quantidade = quantidade;
            Validade = validade;
            DescricaoVenda = descricaovenda;
        }
    }
    /// <summary>
    /// <para>Resumo: Classe espelho para alterar uma postagem</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 05/05/2022</para>
    /// </summary>
    public class AtualizarVendaDTO
    {
        [Required, StringLength(30)]
        public int Id { get; set; }

       [Required, StringLength(100)]
        public string Contato{ get; set; }
       
        [Required]
        public int Quantidade { get; set; }

        [Required, StringLength(30)]
        public string Validade  { get; set; }

       [Required]
        public string DescricaoVenda { get; set; }

        public AtualizarVendaDTO(string contato, int quantidade, string validade, string descricaovenda)
        {

            Contato = contato;
            Quantidade = quantidade;
            Validade = validade;
            DescricaoVenda = descricaovenda;
        }
    }
}
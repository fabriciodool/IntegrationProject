using System.ComponentModel.DataAnnotations;

namespace Doaqui.src.dtos
{
    // <summary>
    /// <para>Resumo: Classe espelho para criar um novo usuario</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 2.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class NovoUsuarioDTO
    {   
        [Required]
        public int  CNPJ_ONG { get; set; }

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

        public NovoUsuarioDTO(int cnpj, string nome, string email, string telefone, string endereco, string senha)
        {   
            CNPJ_ONG = cnpj;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Senha = senha;
        }
    }

    // <summary>
    /// <para>Resumo: Classe espelho para atualizar um usuario</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 2.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class AtualizarUsuarioDTO
    {
        [Required, StringLength(14)]
        public int CNPJ_ONG { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; }

        [Required, StringLength(14)]
        public string Telefone { get; set; }

        [Required, StringLength(50)]
        public string Endereco { get; set; }

        [Required, StringLength(30)]
        public string Senha { get; set; }

        public AtualizarUsuarioDTO(string nome, string telefone, string endereco, string senha)
        {   
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Senha = senha;
        }
    }
}

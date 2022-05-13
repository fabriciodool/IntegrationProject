using System.ComponentModel.DataAnnotations;
using Doaqui.src.utilidades;

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

        [Required]
        public TipoUsuario Tipo { get; set; }

        public NovoUsuarioDTO(int cnpj_ong, string nome, string email, string telefone, string endereco, string senha, TipoUsuario tipo)
        {
            CNPJ_ONG = cnpj_ong;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Senha = senha;
            Tipo = tipo;
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
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Senha { get; set; }

        public AtualizarUsuarioDTO(int cnpj_ong, string nome, string email, string telefone, string endereco, string senha)
        {
            CNPJ_ONG = cnpj_ong;
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Email = email;
            Senha = senha;
        }

        
    }
}

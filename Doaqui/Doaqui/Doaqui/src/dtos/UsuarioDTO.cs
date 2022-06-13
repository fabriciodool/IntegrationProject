using System.ComponentModel.DataAnnotations;
using Doaqui.src.utilidades;

namespace Doaqui.src.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar um novo usuario</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 2.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class NovoUsuarioDTO
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

        [Required, StringLength(12)]
        public int Cnpj { get; set; }

        [Required, StringLength(50)]
        public string Titulo { get; set; }

        public NovoUsuarioDTO(int id, string nome, string email, string telefone, string endereco, string senha, TipoUsuario tipo, int cnpj, string titulo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Senha = senha;
            Tipo = tipo;
            Cnpj = cnpj;
            Titulo = titulo;
        }

    }

    /// <summary>
    /// <para>Resumo: Classe espelho para atualizar um usuario</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 2.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class AtualizarUsuarioDTO
    {
        [Required]
        public int Id { get; set; }

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

        [Required, StringLength(12)]
        public int Cnpj { get; set; }

        [Required, StringLength(50)]
        public int Titulo { get; set; }
        public AtualizarUsuarioDTO(int id, string nome, string email, string telefone, string endereco, string senha, int cnpj)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Senha = senha;
            Cnpj = cnpj;

        }
    }
}
using Doaqui.src.data;
using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;
using System.Linq;

namespace Doaqui.src.repositories.implementations
{

    /// <summary>
    /// <para> Summary: usuario repository implementation of IUsuario interface. </para>
    /// <para> Created by: Nickole Bueno </para>
    /// <para> Version: 1.0 </para>
    /// <para> Date: 05/05/2022 </para>
    /// </summary>
    public class UsuarioRepositorio : IUsuario
    {

        #region Attributes
        private readonly DoaquiContexto _contexto;
        #endregion


        #region Constructors
        public UsuarioRepositorio(DoaquiContexto contexto)
        {
            _contexto = contexto;
        }
        #endregion


        #region Methods
        public void NovoUsuario(NovoUsuarioDTO usuario)
        {
            _contexto.Usuarios.Add(new UsuarioModelo
            {
                CNPJ_ONG = usuario.CNPJ_ONG,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Endereco = usuario.Endereco,
                Senha = usuario.Senha
            });
            _contexto.SaveChanges();
        }

        public void AtualizarUsuario(AtualizarUsuarioDTO usuario)
        {
            UsuarioModelo modelo = PegarUsuarioPeloCnpj(usuario.CNPJ_ONG);
            modelo.Nome = usuario.Nome;
            modelo.Telefone = usuario.Telefone;
            modelo.Endereco = usuario.Endereco;
            modelo.Senha = usuario.Senha;
            _contexto.Update(modelo);
            _contexto.SaveChanges();
        }

        public void DeletarUsuario(int cnpj)
        {
            _contexto.Usuarios.Remove(PegarUsuarioPeloCnpj(cnpj));
            _contexto.SaveChanges();
        }

        public UsuarioModelo PegarUsuarioPeloCnpj(int cnpj)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.CNPJ_ONG == cnpj);
        }

        public UsuarioModelo PegarUsuariosPeloNome(string nome)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.Nome == nome);
        }

        public UsuarioModelo PegarUsuarioPeloContato(string contato)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.Endereco == contato);
        }

        public List<UsuarioModelo> PegarTodosUsuarios()
        {
            return _contexto.Usuarios.ToList();
        }
        #endregion
    }
}

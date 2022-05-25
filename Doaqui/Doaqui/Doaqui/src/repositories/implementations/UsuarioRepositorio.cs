using Doaqui.src.data;
using Doaqui.src.dtos;
using Doaqui.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

         /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo usuario</para>
        /// </summary>
        /// <param name="usuario">NovoUsuarioDTO</param>
        public async Task NovoUsuarioAsync(NovoUsuarioDTO usuario)
        {
            _contexto.Usuarios.Add(new UsuarioModelo
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Endereco = usuario.Endereco,
                Senha = usuario.Senha,
                Tipo = usuario.Tipo,
                Cnpj = usuario.Cnpj

            });
           await _contexto.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para atualizar um usuario</para>
        /// </summary>
        /// <param name="usuario">AtualizarUsuarioDTO</param>
        public async Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario)
        {
            UsuarioModelo modelo = await PegarUsuarioPeloIdAsync(usuario.Id);
            modelo.Nome = usuario.Nome;
            modelo.Telefone = usuario.Telefone;
            modelo.Endereco = usuario.Endereco;
            modelo.Senha = usuario.Senha;
            modelo.Cnpj = usuario.Cnpj;
            _contexto.Update(modelo);
           await _contexto.SaveChangesAsync();
        }

         /// <summary>
        /// <para>Resumo: Método assíncrono para deletar um usuario</para>
        /// </summary>
        /// <param name="id">Id do usuario</param>
        public async Task DeletarUsuarioAsync(int id)
        {
            _contexto.Usuarios.Remove(await PegarUsuarioPeloIdAsync(id));
           await _contexto.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar um usuario pelo Cnpj</para>
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <return>UsuarioModelo</return>
        public async Task<UsuarioModelo> PegarUsuarioPeloIdAsync(int id)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }
        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar usuarios pelo nome</para>
        /// </summary>
        /// <param name="nome">Nome do usuario</param>
        /// <return>Lista UsuarioModelo</return>
        public async Task<List<UsuarioModelo>> PegarUsuariosPeloNomeAsync(string nome)
        {
            return await _contexto.Usuarios
            .Where(u => u.Nome == nome)
            .ToListAsync();
        }
         /// <summary>
        /// <para>Resumo: Método assíncrono para pegar um usuario pelo email</para>
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <return>UsuarioModelo</return>
        public async Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
        #endregion
    }
}

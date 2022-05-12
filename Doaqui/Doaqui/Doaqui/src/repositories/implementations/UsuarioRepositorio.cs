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
        public async Task NovoUsuarioAsync(NovoUsuarioDTO usuario)
        {
            _contexto.Usuarios.Add(new UsuarioModelo
            {
                CNPJ_ONG = usuario.CNPJ_ONG,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Endereco = usuario.Endereco,
                Senha = usuario.Senha,
                Tipo = usuario.Tipo

            });
           await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario)
        {
            UsuarioModelo modelo = await PegarUsuarioPeloCnpjAsync(usuario.CNPJ_ONG);
            modelo.Nome = usuario.Nome;
            modelo.Telefone = usuario.Telefone;
            modelo.Endereco = usuario.Endereco;
            modelo.Senha = usuario.Senha;
            _contexto.Update(modelo);
           await _contexto.SaveChangesAsync();
        }

        public async Task DeletarUsuarioAsync(int cnpj)
        {
            _contexto.Usuarios.Remove(await PegarUsuarioPeloCnpjAsync(cnpj));
           await _contexto.SaveChangesAsync();
        }

        public async Task<UsuarioModelo> PegarUsuarioPeloCnpjAsync(int cnpj)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.CNPJ_ONG == cnpj);
        }

        public async Task<List<UsuarioModelo>> PegarUsuariosPeloNomeAsync(string nome)
        {
            return await _contexto.Usuarios
            .Where(u => u.Nome == nome)
            .ToListAsync();
        }

        public async Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
        #endregion
    }
}

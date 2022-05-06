using Doaqui.src.data;
using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;
using System.Linq;

namespace Doaqui.src.repositories.implementations
{

    /// <summary>
    /// <para> Summary: User repository implementation of IUsuario interface. </para>
    /// <para> Created by: Nickole Bueno </para>
    /// <para> Version: 1.0 </para>
    /// <para> Date: 05/05/2022 </para>
    /// </summary>
    public class UserRepository : IUsuario
    {

        #region Attributes
        private readonly DoaquiContext _context;
        #endregion


        #region Constructors
        public UserRepository(DoaquiContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods
        public void NewUser(NovoUsuarioDTO user)
        {
            _context.Usuarios.Add(new UsuarioModel
            {
                CNPJ_ONG = user.CNPJ_ONG,
                Nome = user.Nome,
                Email = user.Email,
                Telefone = user.Telefone,
                Endereco = user.Endereco,
                Senha = user.Senha
            });
            _context.SaveChanges();
        }

        public void UpdateUser(AtualizarUsuarioDTO user)
        {
            UsuarioModel model = GetUserByCnpj(user.CNPJ_ONG);
            model.Nome = user.Nome;
            model.Telefone = user.Telefone;
            model.Endereco = user.Endereco;
            model.Senha = user.Senha;
            _context.Update(model);
            _context.SaveChanges();
        }

        public void DeleteUser(int cnpj)
        {
            _context.Usuarios.Remove(GetUserByCnpj(cnpj));
            _context.SaveChanges();
        }

        public UsuarioModel GetUserByCnpj(int cnpj)
        {
            return _context.Usuarios.FirstOrDefault(u => u.CNPJ_ONG == cnpj);
        }

        public UsuarioModel GetUserByName(string name)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Nome == name);
        }

        public UsuarioModel GetUserByAddress(string address)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Endereco == address);
        }

        public List<UsuarioModel> GetAllUsers()
        {
            return _context.Usuarios.ToList();
        }
        #endregion
    }
}

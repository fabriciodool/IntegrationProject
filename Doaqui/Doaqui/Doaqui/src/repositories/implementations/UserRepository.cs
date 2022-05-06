using Doaqui.src.data;
using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;

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
            _context.SaveChanges();
        }

        public void UpdateUser(AtualizarUsuarioDTO user)
        {
            _context.SaveChanges();
        }

        public void DeleteUser(int cnpj)
        {
            _context.SaveChanges();
        }

        public UsuarioModel GetUserByCnpj(int cnpj)
        {
            
        }

        public UsuarioModel GetUserByName(string name)
        {
            
        }

        public UsuarioModel GetUserByAddress(string address)
        {
            
        }

        public List<UsuarioModel> GetAllUsers()
        {
            
        }
        #endregion
    }
}

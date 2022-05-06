using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;

namespace Doaqui.src.repositories
{

    /// <summary>
    /// <para> Summary: Represets all CRUD actions related to users </para>
    /// <para> Created by: Nickole Bueno </para>
    /// <para> Version: 1.0 </para>
    /// <para> Date: 05/05/2022 </para>
    /// </summary>
    public interface IUsuario
    {
        public void NewUser(NovoUsuarioDTO user);
        public void UpdateUser(AtualizarUsuarioDTO user);
        public void DeleteUser(int cnpj);
        public UsuarioModel GetUserByCnpj(int cnpj);
        public UsuarioModel GetUserByName(string name);
        public UsuarioModel GetUserByAddress(string address);
        public List<UsuarioModel> GetAllUsers();
    }

}


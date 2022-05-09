using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Collections.Generic;

namespace Doaqui.src.repositories
{

    /// <summary>
    /// <para> Summary: Representação do CRUD relacionado a usuarios </para>
    /// <para> Created by: Nickole Bueno </para>
    /// <para> Version: 1.0 </para>
    /// <para> Date: 05/05/2022 </para>
    /// </summary>
    public interface IUsuario
    {
        public void NovoUsuario(NovoUsuarioDTO usuario);
        public void AtualizarUsuario(AtualizarUsuarioDTO usuario);
        public void DeletarUsuario(int cnpj);
        public UsuarioModelo PegarUsuarioPeloCnpj(int cnpj);
        List <UsuarioModelo> PegarUsuariosPeloNome(string nome);
        public UsuarioModelo PegarUsuarioPeloContato(string contato);
        public List<UsuarioModelo> PegarTodosUsuarios();
    }

}


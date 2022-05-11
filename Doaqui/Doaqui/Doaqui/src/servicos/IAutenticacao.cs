using Doaqui.src.dtos;
using Doaqui.src.models;
namespace Doaqui.src.servicos

{
    public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        void CriarUsuarioSemDuplicar(NovoUsuarioDTO usuario);
        string GerarToken(UsuarioModelo usuario);
        AutorizacaoDTO PegarAutorizacao(AutenticarDTO autenticacao);
    }
}

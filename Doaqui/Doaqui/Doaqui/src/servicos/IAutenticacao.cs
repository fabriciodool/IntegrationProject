using Doaqui.src.dtos;
using Doaqui.src.models;
using System.Threading.Tasks;

namespace Doaqui.src.servicos

{
    public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        Task CriarUsuarioSemDuplicarAsync(NovoUsuarioDTO usuario);
        string GerarToken(UsuarioModelo usuario);
        Task <AutorizacaoDTO> PegarAutorizacaoAsync(AutenticarDTO autenticacao);
    }
}

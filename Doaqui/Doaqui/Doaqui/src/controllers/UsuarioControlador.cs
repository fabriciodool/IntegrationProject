using System.Threading.Tasks;
using Doaqui.src.dtos;
using Doaqui.src.repositories;
using Microsoft.AspNetCore.Mvc;

namespace Doaqui.src.controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    [Produces("application/json")]
    public class UsuarioControlador : ControllerBase
    {
        #region Atributos
        private readonly IUsuario _repositorio;
        #endregion

        #region Construtores
        public UsuarioControlador(IUsuario repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion Construtores

        #region Métodos
        [HttpGet("id/{idUsuario}")]
        public async Task<ActionResult> PegarUsuarioPeloCnpjAsync([FromRoute] int idUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloCnpjAsync(idUsuario);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult> PegarUsuariosPeloNomeAsync([FromQuery] string nomeUsuario)
        {
            var usuarios = await _repositorio.PegarUsuariosPeloNomeAsync(nomeUsuario);
            if (usuarios.Count < 1) return NoContent();
            return Ok(usuarios);
        }

        [HttpGet("contato/{contatoUsuario}")]
        public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string contatoUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(contatoUsuario);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> NovoUsuarioAsync([FromBody] NovoUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
           await _repositorio.NovoUsuarioAsync(usuario);
            return Created($"api/Usuarios/{usuario.Email}", usuario);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarUsuarioAsync([FromBody] AtualizarUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
           await _repositorio.AtualizarUsuarioAsync(usuario);
            return Ok(usuario);
        }

        [HttpDelete("deletar/{idUsuario}")]
        public async Task<ActionResult> DeletarUsuarioAsync([FromRoute] int idUsuario)
        {
           await _repositorio.DeletarUsuarioAsync(idUsuario);
            return NoContent();
        }
        #endregion Métodos
    }
}
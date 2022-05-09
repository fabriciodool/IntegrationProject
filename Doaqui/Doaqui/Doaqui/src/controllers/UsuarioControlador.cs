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
        public IActionResult PegarUsuarioPeloCnpj([FromRoute] int idUsuario)
        {
            var usuario = _repositorio.PegarUsuarioPeloCnpj(idUsuario);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
         [HttpGet]
        public IActionResult PegarUsuariosPeloNome([FromQuery] string nomeUsuario)
        {
            var usuarios = _repositorio.PegarUsuariosPeloNome(nomeUsuario);
            if (usuarios.Count < 1) return NoContent();
            return Ok(usuarios);
        }
        [HttpGet("contato/{contatoUsuario}")]
        public IActionResult PegarUsuarioPeloContato([FromRoute] string contatoUsuario)
        {
            var usuario = _repositorio.PegarUsuarioPeloContato(contatoUsuario);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
        [HttpPost]
        public IActionResult NovoUsuario([FromBody] NovoUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
            _repositorio.NovoUsuario(usuario);
            return Created($"api/Usuarios/{usuario.Email}", usuario);
        }
         [HttpPut]
        public IActionResult AtualizarUsuario([FromBody] AtualizarUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
            _repositorio.AtualizarUsuario(usuario);
            return Ok(usuario);
        }
         [HttpDelete("deletar/{idUsuario}")]
        public IActionResult DeletarUsuario([FromRoute] int idUsuario)
        {
            _repositorio.DeletarUsuario(idUsuario);
            return NoContent();
        }
        #endregion Métodos
    }
}
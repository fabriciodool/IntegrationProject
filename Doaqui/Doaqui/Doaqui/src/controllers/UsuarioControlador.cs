using System.Threading.Tasks;
using Doaqui.src.dtos;
using Doaqui.src.models;
using Doaqui.src.repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        #endregion 

        #region Métodos
        
        /// <summary>
        /// Pegar usuario pelo Cnpj
        /// </summary>
        /// <param name="Usuario">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna o usuario</response>
        /// <response code="404">Usuario não existente</response>
    
        [HttpGet("id/{idUsuario}")]
        public async Task<ActionResult> PegarUsuarioPeloIdAsync([FromRoute] int idUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloIdAsync(idUsuario);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        /// <summary>
        /// Pegar usuario pelo Nome
        /// </summary>
        /// <param name="nomeUsuario">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna o usuario</response>
        /// <response code="204">Nome não existe</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioModelo))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public async Task<ActionResult> PegarUsuariosPeloNomeAsync([FromQuery] string nomeUsuario)
        {
            var usuarios = await _repositorio.PegarUsuariosPeloNomeAsync(nomeUsuario);
            if (usuarios.Count < 1) return NoContent();
            return Ok(usuarios);
        }

        /// <summary>
        /// Pegar usuario pelo Email
        /// </summary>
        /// <param name="EmailUsuario">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna o usuario</response>
        /// <response code="404">Email não existente</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioModelo))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("contato/{contatoUsuario}")]
        public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string contatoUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(contatoUsuario);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        /// <summary>
        /// Criar novo Usuario
        /// </summary>
        /// <param name="usuario">NovoUsuarioDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/Usuarios
        ///     {
        ///        "nome": "Naomy Santana",
        ///        "email": "naozinha@email.com",
        ///        "senha": "134652",
        ///        "foto": "URLFOTO",
        ///        "tipo": "NORMAL"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna usuario criado</response>
        /// <response code="400">Erro na requisição</response>
        /// <response code="401">E-mail ja cadastrado</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioModelo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult> NovoUsuarioAsync([FromBody] NovoUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
           await _repositorio.NovoUsuarioAsync(usuario);
            return Created($"api/Usuarios/{usuario.Email}", usuario);
        }

        /// <summary>
        /// Atualizar Usuario
        /// </summary>
        /// <param name="usuario">AtualizarUsuarioDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/Usuarios
        ///     {
        ///        "id": 1,    
        ///        "nome": "Naomy Santana",
        ///        "senha": "134652",
        ///        "foto": "URLFOTO"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna usuario atualizado</response>
        /// <response code="400">Erro na requisição</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult> AtualizarUsuarioAsync([FromBody] AtualizarUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
           await _repositorio.AtualizarUsuarioAsync(usuario);
            return Ok(usuario);
        }

        /// <summary>
        /// Deletar usuario pelo Cnpj
        /// </summary>
        /// <param name="Cnpj">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Usuario deletado</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("deletar/{idUsuario}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<ActionResult> DeletarUsuarioAsync([FromRoute] int usuario)
        {
           await _repositorio.DeletarUsuarioAsync(usuario);
            return NoContent();
        }
        #endregion Métodos
    }
}
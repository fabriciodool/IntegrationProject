using Doaqui.src.dtos;
using Microsoft.AspNetCore.Mvc;
using Doaqui.src.repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Doaqui.src.models;

namespace Doaqui.src.controllers
{
    [ApiController]
    [Route("api/Doacao")]
    [Produces("application/json")]
    public class DoacaoControlador :ControllerBase
    {
        #region Atributos

        private readonly IDoacao _repositorio;
        
        #endregion

        #region Construtores

        public DoacaoControlador(IDoacao repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Pegar todas doacoes pelo Cnpj
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna todas doacoes</response>
        /// <response code="404">Usuario não existente</response>
        [HttpGet("todas")]
        public async Task<ActionResult> PegarTodasDoacoesAsync()
        {
            var lista = await _repositorio.PegarTodasDoacoesAsync();
            if (lista.Count < 1) return NoContent();
            
            return Ok(lista);
        }

        /// <summary>
        /// Pegar doacao pelo Cnpj
        /// </summary>
        /// <param name="cnpjDoacao">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna a doacao</response>
        /// <response code="404">Doacao não existente</response>
        [HttpGet("cnpj/{cpnjDoacao}")]
        public async Task<ActionResult> PegarDoacaoPeloCnpjAsync([FromRoute] string cnpjDoacao)
        {
            var tema = await _repositorio.PegarDoacaoPeloCnpjAsync(cnpjDoacao);

            if (tema == null) return NotFound();
            
            return Ok(tema);
        }

        /// <summary>
        /// Pegar usuario pelo Email
        /// </summary>
        /// <param name="contato">E-mail</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna o usuario</response>
        /// <response code="404">Email não existente</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DoacaoModelo))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult> PegarDoacaoPeloContato([FromQuery] string contato)
        {
            var doacoes = await _repositorio.PegarDoacaoPeloContatoAsync(contato);

            if (doacoes == null) return NotFound();
            
            return Ok(doacoes);
        }

         /// <summary>
        /// Criar nova doacao
        /// </summary>
        /// <param name="doacao">NovaDoacaoDTO</param>
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
        /// <response code="201">Retorna doacao feita</response>
        /// <response code="400">Erro na requisição</response>
        /// <response code="401">E-mail ja cadastrado</response>
        [HttpPost]
        public async Task<ActionResult> NovaDoacaoAsync([FromBody] NovaDoacaoDTO doacao)
        {
            if(!ModelState.IsValid) return BadRequest();

           await _repositorio.NovaDoacaoAsync(doacao);

            return Created($"api/Doacoes", doacao);
        }

        /// <summary>
        /// Atualizar Doacao
        /// </summary>
        /// <param name="doacao">AtualizarDoacaoDTO</param>
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
        /// <response code="200">Retorna doacao atualizada</response>
        /// <response code="400">Erro na requisição</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpPut]
        public async Task<ActionResult> AtualizarDoacaoAsync([FromBody] AtualizarDoacaoDTO doacao)
        {
            if(!ModelState.IsValid) return BadRequest();

          await _repositorio.AtualizarDoacaoAsync(doacao);
            
            return Ok(doacao);
        }

        /// <summary>
        /// Deletar doacao pelo Cnpj
        /// </summary>
        /// <param name="idDoacao">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Doacaio deletada</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [HttpDelete("deletar/{idDoacao}")]
        public async Task<ActionResult> DeletarDoacaoAsync([FromRoute] int idDoacao)
        {
           await _repositorio.DeletarDoacaoAsync(idDoacao);
            return NoContent();
        }

        #endregion
    }
}
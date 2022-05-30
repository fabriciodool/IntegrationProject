using System.Threading.Tasks;
using Doaqui.src.dtos;
using Doaqui.src.models;
using Doaqui.src.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doaqui.src.controllers
{

    [ApiController]
    [Route("api/Solicitacao")]
    [Produces("application/json")]
    public class SolicitacaoControlador : ControllerBase
    {
        #region Atbutos

        private readonly ISolicitacao _repositorio;

        #endregion

        #region Contrutores
        public SolicitacaoControlador(ISolicitacao repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Pegar solicitacao pelo Cnpj
        /// </summary>
        /// <param name="idsolicitacao">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna a solicitacao</response>
        /// <response code="404">Usuario não existente</response>
        [HttpGet("cnpj/{idsolicitacao}")]
        public async Task<ActionResult> PegarSolicitacaoPeloCnpjAsync([FromRoute] int idsolicitacao)
        {
            var solicitacao = await _repositorio.PegarSolicitacaoPeloCnpjAsync(idsolicitacao);

            if (solicitacao == null) return NotFound();

            return Ok(solicitacao);
        }

         /// <summary>
        /// Pegar todas solicitacoes pelo Cnpj
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna todas solicitacoes</response>
        /// <response code="404">Usuario não existente</response>
        [HttpGet]
        public async Task<ActionResult> PegarTodasSolicitacoesAsync()
        {
            var lista = await _repositorio.PegarTodasSolicitacoesAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        /// <summary>
        /// Criar nova solicitacao
        /// </summary>
        /// <param name="solicitacao">NovaSolicitacaoDTO</param>
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
        /// <response code="201">Retorna solicitacao criado</response>
        /// <response code="400">Erro na requisição</response>
        /// <response code="401">E-mail ja cadastrado</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SolicitacaoModelo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> NovaSolicitacaoAsync(NovaSolicitacaoDTO solicitacao)
        {
            if (ModelState.IsValid) return BadRequest();

           await _repositorio.NovaSolicitacaoAsync(solicitacao);

            return Created($"api/Solicitacao", solicitacao);

        }

        /// <summary>
        /// Atualizar Solicitacao
        /// </summary>
        /// <param name="solicitacao">AtualizarSolicitacaoDTO</param>
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
        /// <response code="200">Retorna solicitacao atualizada</response>
        /// <response code="400">Erro na requisição</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult> AtualizarSolicitacaoAsync([FromBody] AtualizarSolicitacaoDTO solicitacao)
        {
            if (!ModelState.IsValid) return BadRequest();

           await _repositorio.AtualizarSolicitacaoAsync(solicitacao);

            return Ok(solicitacao);
        }
        /// <summary>
        /// Deletar solicitacao pelo Cnpj
        /// </summary>
        /// <param name="idsolicitacao">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Usuario deletado</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("delete/{idsolicitacao}")]
        public async Task<ActionResult> DeletarSolicitacaoAsync([FromRoute] int idsolicitacao)
        {
           await _repositorio.DeletarSolicitacaoAsync(idsolicitacao);
            return NoContent();
        }

        #endregion
    }
}

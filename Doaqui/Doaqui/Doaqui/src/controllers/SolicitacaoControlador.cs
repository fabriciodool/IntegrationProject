using System.Threading.Tasks;
using Doaqui.src.dtos;
using Doaqui.src.repositories;
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

        [HttpGet("cnpj/{idsolicitacao")]
        public async Task<ActionResult> PegarSolicitacaoPeloCnpjAsync([FromRoute] int cnpjSolicitacao)
        {
            var solicitacao = await _repositorio.PegarSolicitacaoPeloCnpjAsync(cnpjSolicitacao);

            if (solicitacao == null) return NotFound();

            return Ok(solicitacao);
        }

        [HttpGet]
        public async Task<ActionResult> PegarTodasSolicitacoesAsync()
        {
            var lista = await _repositorio.PegarTodasSolicitacoesAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> NovaSolicitacaoAsync(NovaSolicitacaoDTO solicitacao)
        {
            if (ModelState.IsValid) return BadRequest();

           await _repositorio.NovaSolicitacaoAsync(solicitacao);

            return Created($"api/Solicitacao", solicitacao);

        }

        [HttpPut]
        public async Task<ActionResult> AtualizarSolicitacaoAsync([FromBody] AtualizarSolicitacaoDTO solicitacao)
        {
            if (!ModelState.IsValid) return BadRequest();

           await _repositorio.AtualizarSolicitacaoAsync(solicitacao);

            return Ok(solicitacao);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletarSolicitacaoAsync([FromRoute] int cnpjSolicitacao)
        {
           await _repositorio.DeletarSolicitacaoAsync(cnpjSolicitacao);
            return NoContent();
        }

        #endregion
    }
}

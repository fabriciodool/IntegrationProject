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

        [HttpGet("id/{idsolicitacao")]
        public IActionResult PegarSolicitacaoPeloId([FromRoute] int idSolicitacao)
        {
            var solicitacao = _repositorio.PegarSolicitacaoPeloId(idSolicitacao);

            if (solicitacao == null) return NotFound();

            return Ok(solicitacao);
        }

        [HttpGet]
        public IActionResult PegarTodasSolicitacoes()
        {
            var lista = _repositorio.PegarTodasSolicitacoes();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        [HttpPost]
        public IActionResult NovaSolicitacao(NovaSolicitacaoDTO solicitacao)
        {
            if (ModelState.IsValid) return BadRequest();

            _repositorio.NovaSolicitacao(solicitacao);

            return Created($"api/Solicitacao", solicitacao);

        }

        [HttpPut]
        public IActionResult AtualizarSolicitacao([FromBody] AtualizarSolicitacaoDTO solicitacao)
        {
            if (!ModelState.IsValid) return BadRequest();

            _repositorio.AtualizarSolicitacao(solicitacao);

            return Ok(solicitacao);
        }

        [HttpDelete]
        public IActionResult DeletarSolicitacao([FromRoute] int idSolicitacao)
        {
            _repositorio.DeletarSolicitacao(idSolicitacao);
            return NoContent();
        }

        #endregion
    }
}

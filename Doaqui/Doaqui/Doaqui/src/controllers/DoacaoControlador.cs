using Doaqui.src.dtos;
using Microsoft.AspNetCore.Mvc;
using Doaqui.src.repositories;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult> PegarTodasDoacoesAsync()
        {
            var lista = await _repositorio.PegarTodasDoacoesAsync();
            if (lista.Count < 1) return NoContent();
            
            return Ok(lista);
        }

        [HttpGet("id/{cpnjDoacao}")]
        public async Task<ActionResult> PegarDoacaoPeloCnpjAsync([FromRoute] int cnpjDoacao)
        {
            var tema = await _repositorio.PegarDoacaoPeloCnpjAsync(cnpjDoacao);

            if (tema == null) return NotFound();
            
            return Ok(tema);
        }

        [HttpGet]
        public async Task<ActionResult> PegarDoacaoPeloContato([FromQuery] string contato)
        {
            var doacoes = await _repositorio.PegarDoacaoPeloContatoAsync(contato);

            if (doacoes == null) return NotFound();
            
            return Ok(doacoes);
        }

        [HttpPost]
        public async Task<ActionResult> NovaDoacaoAsync([FromBody] NovaDoacaoDTO doacao)
        {
            if(!ModelState.IsValid) return BadRequest();

           await _repositorio.NovaDoacaoAsync(doacao);

            return Created($"api/Doacoes", doacao);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarDoacaoAsync([FromBody] AtualizarDoacaoDTO doacao)
        {
            if(!ModelState.IsValid) return BadRequest();

          await _repositorio.AtualizarDoacaoAsync(doacao);
            
            return Ok(doacao);
        }

        [HttpDelete("deletar/{idDoacao}")]
        public async Task<ActionResult> DeletarDoacaoAsync([FromRoute] int idDoacao)
        {
           await _repositorio.DeletarDoacaoAsync(idDoacao);
            return NoContent();
        }

        #endregion
    }
}
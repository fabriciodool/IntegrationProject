using Doaqui.src.dtos;
using Microsoft.AspNetCore.Mvc;
using Doaqui.src.repositories;

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
        public IActionResult PegarTodasDoacoes()
        {
            var lista = _repositorio.PegarTodasDoacoes();
            if (lista.Count < 1) return NoContent();
            
            return Ok(lista);
        }
        [HttpGet("id/{idTema}")]
        public IActionResult PegarDoacaoPeloCnpj([FromRoute] int CnpjDoacao)
        {
            var tema = _repositorio.PegarDoacaoPeloCnpj(CnpjDoacao);

            if (tema == null) return NotFound();
            
            return Ok(tema);
        }
        [HttpGet]
        public IActionResult PegarDoacaoPelaDescricaoDoacao([FromQuery] string descricao)
        {
              var doacoes = _repositorio.PegarDoacaoPelaDescricaoDoacao(descricao);

            if (doacoes.Count < 1) return NoContent();
            
            return Ok(doacoes);
        }
         [HttpPost]
        public IActionResult NovaDoacao([FromBody] NovaDoacaoDTO)
        {
            if(!ModelState.IsValid) return BadRequest();

            _repositorio.NovaDoacao(doacao)
            
            return Created($"api/Doacoes", doacao)
        }
        [HttpPut]
        public IActionResult AtualizarDoacao([FromBody] AtualizarDoacaoDTO doacao)
        {
            if(!ModelState.IsValid) return BadRequest();

            _repositorio.AtualizarDoacao(doacao);
            
            return Ok(doacao);
        }
        [HttpDelete("deletar/{idDoacao}")]
        public IActionResult DeletarDoacao([FromRoute] int idDoacao)
        {
            _repositorio.DeletarDoacao(idDoacao);
            return NoContent();
        }

        #endregion
    }
}
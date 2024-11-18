
using Action.Api.DTOs;
using Action.Api.Models;
using Action.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Action.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoService _solicitacaoService;

        public SolicitacaoController(ISolicitacaoService solicitacaoService)
        {
            _solicitacaoService = solicitacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitacaoDTO>>> GetAllSolicitacoes()
        {
            var solicitacoes =  await _solicitacaoService.GetAllSolicitacoes();
            return Ok(solicitacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitacaoDTO>> GetSolicitacaoById(int id)
        {
            var solicitacao = await _solicitacaoService.GetSolicitacaoById(id);
            return Ok(solicitacao);
        }

        [HttpPost]
        public async Task<ActionResult<SolicitacaoDTO>> CreateSolicitacao(SolicitacaoDTO solicitacaoDTO)
        {
            var solicitacao = await _solicitacaoService.CreateSolicitacao(solicitacaoDTO);
            return CreatedAtAction(nameof(GetSolicitacaoById), new { id = solicitacao.Id }, solicitacao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SolicitacaoDTO>> UpdateSolicitacao(int id, SolicitacaoDTO solicitacaoDTO)
        {
            var solicitacao = await _solicitacaoService.UpdateSolicitacao(id, solicitacaoDTO);
            return Ok(solicitacao);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSolicitacao(int id)
        {
            await _solicitacaoService.DeleteSolicitacao(id);
            return NoContent();
        }
    }

}
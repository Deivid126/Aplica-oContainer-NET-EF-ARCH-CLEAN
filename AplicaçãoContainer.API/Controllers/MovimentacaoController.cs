using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AplicaçãoContainer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacaoController(IMovimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Movimentacao>>> FindAll() 
        {
            var movimentacaos = await _movimentacaoService.GetAllMovimentacao();

            return Ok(movimentacaos);
        }


        [HttpGet("container")]
        [Authorize]
        public async Task<ActionResult<List<Movimentacao>>> FindAllMovimentacaoContainer( Guid id )
        {
            var movimentacaos = await _movimentacaoService.GetAllMovimentacao();

            return Ok(movimentacaos);
        }


        [HttpDelete]
        [Authorize]
        public ActionResult Delete(Guid id) 
        
        {

            _movimentacaoService.DeleteMovimentacao(id);

            return NoContent();
        
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Movimentacao>> Save(MovimentacaoDTO movimentacao)
        {
            var movisave = await _movimentacaoService.Create(movimentacao);

            return Ok(movisave);

        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Movimentacao>> Uptade (Movimentacao movimentacao) 
        {

            var moviuptade = await _movimentacaoService.Update(movimentacao);

            return Ok(moviuptade);
        }


    }
}

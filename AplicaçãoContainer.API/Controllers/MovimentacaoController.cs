using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
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
        public async Task<ActionResult<List<Movimentacao>>> FindAll() 
        {
            var movimentacaos = await _movimentacaoService.GetAllMovimentacao();

            return Ok(movimentacaos);
        }

       

        [HttpDelete]
        public ActionResult Delete(Guid id) 
        
        {

            _movimentacaoService.DeleteMovimentacao(id);

            return Ok();
        
        }

        [HttpPost]
        public async Task<ActionResult<Movimentacao>> Save(MovimentacaoDTO movimentacao)
        {
            var movisave = await _movimentacaoService.Create(movimentacao);

            return Ok(movisave);

        }

        [HttpPut]
        public async Task<ActionResult<Movimentacao>> Uptade (Movimentacao movimentacao) 
        {

            var moviuptade = await _movimentacaoService.Update(movimentacao);

            return Ok(moviuptade);
        }


    }
}

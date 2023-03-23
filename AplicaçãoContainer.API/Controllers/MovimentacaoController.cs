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
        public ActionResult FindAll() 
        {
            var movimentacaos = _movimentacaoService.GetAllMovimentacao();

            return Ok(movimentacaos);
        }

       

        [HttpDelete]
        public ActionResult Delete(Guid id) 
        
        {

            _movimentacaoService.DeleteMovimentacao(id);

            return Ok();
        
        }

        [HttpPost]
        public ActionResult Save(MovimentacaoDTO movimentacao)
        {
            var movisave = _movimentacaoService.Create(movimentacao);

            return Ok(movisave);

        }

        [HttpPut]
        public ActionResult Uptade (Movimentacao movimentacao) 
        {

            var moviuptade = _movimentacaoService.Update(movimentacao);

            return Ok(moviuptade);
        }


    }
}

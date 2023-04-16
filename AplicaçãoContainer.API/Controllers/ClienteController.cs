using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AplicaçãoContainer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<Cliente>> Register(ClienteDTO cliente)
        {

            var clinte = await _clienteService.Register(cliente);

            return Ok(clinte);
        
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticateResponse>> Autenticate(AuthenticateRequest authenticate)
        {

            var jwt = await _clienteService.Authenticate(authenticate);

            return Ok(jwt);

        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Cliente>>> Get() 
        {
            var clientes = await _clienteService.GetAll();

            return Ok(clientes);
        }
    }
}

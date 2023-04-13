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
        private IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(ClienteDTO cliente) 
        {

            var clinte = clienteService.Register(cliente);

            return Ok(clinte);
        
        }

        [HttpPost("autenticate")]
        [AllowAnonymous]
        public IActionResult Autenticate(AuthenticateRequest authenticate)
        {

            var jwt = clienteService.Authenticate(authenticate);

            return Ok(jwt);

        }

        [HttpGet]
        [Authorize]
        public IActionResult Get() 
        {
            var clientes = clienteService.GetAll();

            return Ok(clientes);
        }
    }
}

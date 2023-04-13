using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
using AplicaçãoContainer.Infratructure.Data;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ContainerDb _containerDb;
        private readonly IJwtService _jwtService;

        public ClienteService(IClienteRepository clienteRepository, ContainerDb containerDb, IJwtService jwtService)
        {
            _clienteRepository = clienteRepository;
            _containerDb = containerDb;
            _jwtService = jwtService;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest user)
        {
            var cliente = _containerDb.Clientes.SingleOrDefault(x => x.Email == user.email);

            if (cliente == null || !BCrypt.Net.BCrypt.Verify(user.password, cliente.PasswordHash)) 
            {
                throw new Exception("Username or password is incorrect");
            }

            var jwt = _jwtService.GenerateToken(cliente);

            AuthenticateResponse jwtToken = new AuthenticateResponse();
            jwtToken.jwt = jwt;

            return jwtToken;

        }

        public void DeleteClienteAsync(Guid id)
        {
            _clienteRepository.DeleteClienteAsync(id);
        }

        public Task<Cliente> FindCliente(Guid id)
        {
            return _clienteRepository.FindCliente(id);
        }

        public Task<List<Cliente>> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Task<Cliente> Register(ClienteDTO cliente)
        {
            if(_containerDb.Clientes.Any( x => x.Email == cliente.Email)) 
            { 
                throw new Exception("Cliente já está cadastrado"); 
            }

            var clientenew =  _clienteRepository.Create(cliente);

            return clientenew;
        }

        public Task<Cliente> Update(Cliente cliente)
        {
            return _clienteRepository.Update(cliente);
        }
    }
}

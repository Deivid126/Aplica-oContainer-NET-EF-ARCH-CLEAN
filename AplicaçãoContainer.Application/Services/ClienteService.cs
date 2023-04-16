using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
using AplicaçãoContainer.Infratructure.Data;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;

        public ClienteService(IClienteRepository clienteRepository, ContainerDb containerDb, 
            IJwtService jwtService, IMemoryCache memoryCache)
        {
            _clienteRepository = clienteRepository;
            _containerDb = containerDb;
            _jwtService = jwtService;
            _memoryCache = memoryCache;
        }

        public  async Task<AuthenticateResponse> Authenticate(AuthenticateRequest user)
        {
            var cliente = await _containerDb.Clientes.SingleOrDefaultAsync(x => x.Email == user.email);

            if (cliente == null || !BCrypt.Net.BCrypt.Verify(user.password, cliente.PasswordHash)) 
            {
                throw new Exception("Username or password is incorrect");
            }

            var jwt = await Task.Run(() => _jwtService.GenerateToken(cliente));

            AuthenticateResponse jwtToken = new AuthenticateResponse
            {
                jwt = jwt
            };

            return jwtToken;

        }

        public async void DeleteClienteAsync(Guid id)
        {
            await Task.Run(() => _clienteRepository.DeleteClienteAsync(id));
        }

        public async Task<Cliente> FindCliente(Guid id)
        {
            var cachedClient = await Task.Run(() => _memoryCache.GetOrCreateAsync($"cliente_{id}", entry =>
            {

                entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                entry.Priority = CacheItemPriority.High;

                return  _clienteRepository.FindCliente(id);

            }));

            return cachedClient;
        }

        public async Task<List<Cliente>> GetAll()
        {
            var cachedClients = await Task.Run(() => _memoryCache.GetOrCreateAsync("clientes", entry =>
            {

                entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                entry.Priority = CacheItemPriority.High;

                return _clienteRepository.GetAll();

            }));

            return cachedClients;
        }

        public async Task<Cliente> Register(ClienteDTO cliente)
        {
            if(_containerDb.Clientes.Any( x => x.Email == cliente.Email)) 
            { 
                throw new Exception("Cliente já está cadastrado"); 
            }

            return await Task.Run(() => _clienteRepository.Create(cliente));

        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            return await Task.Run(() => _clienteRepository.Update(cliente));
        }
    }
}

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

namespace AplicaçãoContainer.Infratructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContainerDb _containerDb;

        public ClienteRepository(ContainerDb containerDb)
        {
            _containerDb = containerDb;
        }
        public async Task<Cliente> Create(Cliente cliente)
        {
            cliente.PasswordHash = BCrypt.Net.BCrypt.HashPassword(cliente.PasswordHash);
            var containernew = await _containerDb.Clientes.AddAsync(cliente);
            _containerDb.SaveChanges();

            return containernew.Entity;
        }

        public async void DeleteClienteAsync(Guid id)
        {
            var cliente = await _containerDb.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _containerDb.Clientes.Remove(cliente);
            }
        }

        public async Task<Cliente> FindCliente(Guid id)
        {
            var cliente = await _containerDb.Clientes.FindAsync(id);
            if (cliente != null)
            {
                return cliente;
            }
            return null;
        }

        public  async Task<Cliente> FindClienteAuth(string email)
        {
            Cliente cliente = await _containerDb.Clientes.FirstAsync(u => u.Email == email);

            if(cliente != null) 
            {
                return cliente; 
            }

            return null;

        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _containerDb.Clientes.ToListAsync();
        }

        public async  Task<Cliente> Update(Cliente cliente)
        {
            _containerDb.Clientes.Update(cliente);
            _containerDb.SaveChanges();
            var clienteupdate = await _containerDb.Clientes.FindAsync(cliente.Id);
            return clienteupdate;

        }
    }
}

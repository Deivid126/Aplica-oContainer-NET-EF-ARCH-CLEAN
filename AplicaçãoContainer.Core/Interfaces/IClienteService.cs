using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Core.Interfaces
{
    public interface IClienteService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticate);

        Task<Cliente> Register(ClienteDTO cliente);

        Task<Cliente> FindCliente(Guid id);

        Task<List<Cliente>> GetAll();

        void DeleteClienteAsync(Guid id);


        Task<Cliente> Update(Cliente container);
    }
}

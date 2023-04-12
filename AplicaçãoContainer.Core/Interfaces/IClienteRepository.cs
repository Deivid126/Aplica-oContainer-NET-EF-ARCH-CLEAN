using AplicaçãoContainer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> FindCliente(Guid id);

        Task<List<Cliente>> GetAll();

        Task<Cliente> FindClienteAuth(string email);

        void DeleteClienteAsync(Guid id);

        Task<Cliente> Create(Cliente container);

        Task<Cliente> Update(Cliente container);
    }
}

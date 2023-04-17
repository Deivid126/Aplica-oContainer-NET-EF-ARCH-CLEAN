using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Core.Interfaces
{
    public interface IContainerService
    {
        Task<Container> FindContainer(Guid id);
        void DeleteContainerAsync(Guid id);

        Task<List<Container>> GetAllContainers();

        Task<Container> Create(ContainerDTO container, Guid clienteid);

        Task<Container> Update(Container container);
    }
}

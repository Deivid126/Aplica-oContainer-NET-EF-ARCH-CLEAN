using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
using AplicaçãoContainer.Infratructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Application.Services
{
    public class ContainerService : IContainerService
    {
        private readonly IContainerRepository _containerRepository;

        public ContainerService(IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }

        public Task<Container> Create(ContainerDTO container)
        {
            Container containernew = new Container();
            containernew.Numero_Container = container.Numero_Container;
            containernew.Cliente = container.Cliente;
            containernew.Categoria = container.Categoria;
            containernew.Tipo = container.Tipo;
            containernew.Status = container.Status;

            return _containerRepository.Create(containernew);
        }

        public void DeleteContainerAsync(Guid id)
        {
            _containerRepository.DeleteContainerAsync(id);
        }

        public Task<Container> FindContainer(Guid id)
        {
           return _containerRepository.FindContainer(id);
        }

        public Task<List<Container>> GetAllContainers()
        {
            return _containerRepository.GetAllContainers();
        }

        public Task<Container> Update(Container container)
        {

            return _containerRepository.Update(container);
        }
    }
}

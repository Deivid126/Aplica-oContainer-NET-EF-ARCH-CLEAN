using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
using AplicaçãoContainer.Infratructure.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IMemoryCache _memoryCache;

        public ContainerService(IContainerRepository containerRepository, IMemoryCache memoryCache)
        {
            _containerRepository = containerRepository;
            _memoryCache = memoryCache;
        }

        public async Task<Container> Create(ContainerDTO container)
        {
            Container containernew = new Container();
            containernew.Numero_Container = container.Numero_Container;
            containernew.Categoria = container.Categoria;
            containernew.Tipo = container.Tipo;
            containernew.Status = container.Status;

            return await Task.Run(() => _containerRepository.Create(containernew));
        }

        public async void DeleteContainerAsync(Guid id)
        {
            await Task.Run(() => _containerRepository.DeleteContainerAsync(id));
        }

        public async Task<Container> FindContainer(Guid id)
        {
            var cachedContainer = await Task.Run(() => _memoryCache.GetOrCreateAsync($"container_{id}", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                entry.Priority = CacheItemPriority.High;
                return _containerRepository.FindContainer(id);

            }));

            return cachedContainer;
        }

        public async Task<List<Container>> GetAllContainers()
        {
            var cachedContainers = await Task.Run(() => _memoryCache.GetOrCreateAsync("containers", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                entry.Priority = CacheItemPriority.High;
                return _containerRepository.GetAllContainers();

            }));

            return cachedContainers;
        }

        public async Task<Container> Update(Container container)
        {
            return await Task.Run(() => _containerRepository.Update(container));
        }
    }
}

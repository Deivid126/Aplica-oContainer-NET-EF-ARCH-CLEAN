using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
using AplicaçãoContainer.Infratructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Infratructure.Repositories
{
    public class ContainerRepository : IContainerRepository
    {
        private readonly ContainerDb _containerDb;

        public ContainerRepository(ContainerDb containerDb)
        {
            _containerDb = containerDb;
        }

        public async Task<Container> Create(Container container)
        {
            var containernew = await _containerDb.Containers.AddAsync(container);
            _containerDb.SaveChanges();

            return containernew.Entity;

        }

        public async void DeleteContainerAsync(Guid id)
        {
           var container = await _containerDb.Containers.FindAsync(id);
            if (container != null)
            {
                _containerDb.Containers.Remove(container);
            }
        }

        public async Task<Container> FindContainer(Guid id)
        {
            var container = await _containerDb.Containers.FindAsync(id);
            if (container != null) 
            { return container; }
            return null;
        }

        public async Task<List<Container>> GetAllContainers()
        {
            return await _containerDb.Containers.ToListAsync();
        }

        public async Task<Container> Update(Container container)
        {
            _containerDb.Containers.Update(container);
            _containerDb.SaveChanges();
            var containernew = await _containerDb.Containers.FindAsync(container.Id);
            return containernew;

        }
    }
}

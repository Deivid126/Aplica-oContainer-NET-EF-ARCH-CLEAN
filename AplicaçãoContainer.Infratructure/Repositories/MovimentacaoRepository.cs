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
    public class MovimentacaoRepository : IMovimetacaoRepository
    {
        private readonly ContainerDb _containerDb;

        public MovimentacaoRepository(ContainerDb containerDb)
        {
            _containerDb = containerDb;
        }
        public async Task<Movimentacao> Create(Movimentacao movimentacao)
        {
            var movimentacaonew = await _containerDb.Movimentacaos.AddAsync(movimentacao);
            _containerDb.SaveChanges();
            return movimentacaonew.Entity;
        }

        public async void DeleteMovimentacao(Guid id)
        {
            var container = await _containerDb.Movimentacaos.FindAsync(id);
            if (container != null) 
            {
              _containerDb.Movimentacaos.Remove(container);
            }
        }

        public Task<List<Movimentacao>> FindContainer(Guid id)
        {
           throw new NotImplementedException();
        }

        public async Task<Movimentacao> FindMovimentacao(Guid id)
        {
            var container = await _containerDb.Movimentacaos.FindAsync(id);
            if (container != null) 
            { 
             return container;
            }

            return null;
        }

        public async Task<List<Movimentacao>> GetAllMovimentacao()
        {
            var movimentacaos = await _containerDb.Movimentacaos.ToListAsync();
            return movimentacaos;
        }

        public async Task<Movimentacao> Update(Movimentacao movimentacao)
        {
            _containerDb.Movimentacaos.Update(movimentacao);
            _containerDb.SaveChanges();
            var uptade = await _containerDb.Movimentacaos.FindAsync(movimentacao.Id);
            return uptade;
        }
    }
}

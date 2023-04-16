using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
using AplicaçãoContainer.Infratructure.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Application.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimetacaoRepository _movimetacaoRepository;
        private readonly IMemoryCache _memoryCache;

        public MovimentacaoService(IMovimetacaoRepository movimetacaoRepository, IMemoryCache memoryCache)
        {
            _movimetacaoRepository = movimetacaoRepository;
            _memoryCache = memoryCache;
        }

        public async Task<Movimentacao> Create(MovimentacaoDTO movimentacao)
        {
            Movimentacao movi  = new Movimentacao();
            movi.TipoMovimentacao = movimentacao.TipoMovimentacao;
            movi.DataFinal = movimentacao.DataFinal;
            movi.DataInicial = movimentacao.DataInicial;
            return  await Task.Run(() =>_movimetacaoRepository.Create(movi));
        }

        public async void DeleteMovimentacao(Guid id)
        {
           await Task.Run(() => _movimetacaoRepository.DeleteMovimentacao(id));
        }

        public async Task<List<Movimentacao>> FindContainer(Guid id)
        {
           throw new NotFiniteNumberException();
        }

        public async Task<Movimentacao> FindMovimentacao(Guid id)
        {
            var cachedMovimentacao = await Task.Run(() => _memoryCache.GetOrCreateAsync($"movimentacao_{id}", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                entry.Priority = CacheItemPriority.High;
                return _movimetacaoRepository.FindMovimentacao(id) ;

            }));

            return cachedMovimentacao;
        }

        public async Task<List<Movimentacao>> GetAllMovimentacao()
        {
            var cachedMovimentacaos = await Task.Run(() => _memoryCache.GetOrCreateAsync("movimentacao", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                entry.Priority = CacheItemPriority.High;
                return _movimetacaoRepository.GetAllMovimentacao();

            }));

            return cachedMovimentacaos;
        }

        public async Task<Movimentacao> Update(Movimentacao movimentacao)
        {
            return await Task.Run(() => _movimetacaoRepository.Update(movimentacao));
        }
    }
}

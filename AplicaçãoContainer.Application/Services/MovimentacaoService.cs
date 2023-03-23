using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Core.Models;
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

        public MovimentacaoService(IMovimetacaoRepository movimetacaoRepository)
        {
            _movimetacaoRepository = movimetacaoRepository;
        }

        public Task<Movimentacao> Create(MovimentacaoDTO movimentacao)
        {
            Movimentacao movi  = new Movimentacao();
            movi.TipoMovimentacao = movimentacao.TipoMovimentacao;
            movi.DataFinal = movimentacao.DataFinal;
            movi.DataInicial = movimentacao.DataInicial;
            return _movimetacaoRepository.Create(movi);
        }

        public void DeleteMovimentacao(Guid id)
        {
            _movimetacaoRepository.DeleteMovimentacao(id);
        }

        public Task<Movimentacao> FindMovimentacao(Guid id)
        {
            return _movimetacaoRepository.FindMovimentacao(id);
        }

        public Task<List<Movimentacao>> GetAllMovimentacao()
        {
            return _movimetacaoRepository.GetAllMovimentacao();
        }

        public Task<Movimentacao> Update(Movimentacao movimentacao)
        {
            return _movimetacaoRepository.Update(movimentacao);
        }
    }
}

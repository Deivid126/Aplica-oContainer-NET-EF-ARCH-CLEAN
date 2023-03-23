using AplicaçãoContainer.Core.DTOs;
using AplicaçãoContainer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Core.Interfaces
{
    public interface IMovimetacaoRepository
    {
        Task<Movimentacao> FindMovimentacao(Guid id);
        void DeleteMovimentacao(Guid id);

        Task<List<Movimentacao>> GetAllMovimentacao();

        Task<Movimentacao> Create(Movimentacao movimentacao);

        Task<Movimentacao> Update(Movimentacao movimentacao);
    }
}

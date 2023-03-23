using AplicaçãoContainer.Core.Enums;
using AplicaçãoContainer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Core.DTOs
{
    public class MovimentacaoDTO
    {
        public TipoMovimentacao TipoMovimentacao { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public ICollection<Container> Container { get; set; }
    }
}

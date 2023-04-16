using AplicaçãoContainer.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Core.Models
{
    public class Movimentacao
    {

        public Guid Id { get; set; }

        public TipoMovimentacao TipoMovimentacao { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set;}

        public ICollection<Container>? Container { get; set; }

          
    }
}

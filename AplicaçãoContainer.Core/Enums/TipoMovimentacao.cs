using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Core.Enums
{
    public enum TipoMovimentacao
    {
        Embarque = 0, 
        Descarga = 1, 
        Gate_in = 2, 
        Gate_out = 3, 
        Reposicionamento = 4,
        Pesagem = 5, 
        Scanner = 6
    }
}

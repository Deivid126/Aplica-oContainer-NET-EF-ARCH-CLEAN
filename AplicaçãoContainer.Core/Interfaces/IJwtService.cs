using AplicaçãoContainer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Core.Interfaces
{
    public interface IJwtService
    {
        Guid? ValidateToken(string token);

        String GenerateToken(Cliente cliente);
    }
}

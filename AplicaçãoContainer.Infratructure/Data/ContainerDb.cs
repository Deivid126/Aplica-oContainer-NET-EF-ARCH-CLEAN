using AplicaçãoContainer.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Infratructure.Data
{
    public class ContainerDb : DbContext
    {
        public ContainerDb(DbContextOptions<ContainerDb> options) : base(options)
        {
           
        }


        public DbSet<Container> Containers { get; set; }
        public DbSet<Movimentacao> Movimentacaos {get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        

    }
}

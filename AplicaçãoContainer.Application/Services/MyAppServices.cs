using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Infratructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Application.Services
{
    public class MyAppServices
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IContainerRepository, ContainerRepository>();
            services.AddScoped<IMovimetacaoRepository, MovimentacaoRepository>();
            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<IMovimentacaoService, MovimentacaoService>();
        }
    }
}

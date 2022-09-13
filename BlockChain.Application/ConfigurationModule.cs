using BlockChain.Application.BlockChain.Service;
using BlockChain.Cross.Utils;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Application.ConfigurationModule).Assembly);
            services.AddMediatR(typeof(Application.ConfigurationModule).Assembly);

            services.AddScoped<ICarteiraService, CarteiraService>();
            services.AddScoped<IHistoricoService, HistoricoService>();
            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IGenericService, GenericService>();
            services.AddScoped<INftService, NftService>();

            services.AddScoped<AzureBlobStorage>();
            services.AddHttpClient();


            return services;
        }
    }
}

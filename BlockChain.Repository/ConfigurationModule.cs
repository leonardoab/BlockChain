using BlockChain.Domain.BlockChain.Repository;
using BlockChain.Repository.Context;
using BlockChain.Repository.Database;
using BlockChain.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Repository
{
    public static class ConfigurationModule
    {

        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BlockChainContext>(c =>
            {
                c.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(Repository<>));
            services.AddScoped<ICarteiraRepository, CarteiraRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IHistoricoRepository, HistoricoRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            

            return services;
        }

    }
}

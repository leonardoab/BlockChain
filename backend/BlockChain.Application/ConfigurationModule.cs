using BlockChain.Application.BlockChain.Service;
using BlockChain.Cross.Utils;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidIssuer = "http://127.0.0.1:80",
                        ValidAudience = "spotify-api",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ACDt1vR3lXToPQ1g3MyN"))
                    };
                });

            services.AddHttpClient();


            return services;
        }
    }
}

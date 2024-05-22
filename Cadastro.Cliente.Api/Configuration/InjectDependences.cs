using Cadastro.Clientes.Repository.Repositorys;
using Cadastro.Clientes.Repository.Repositorys.Interfaces;
using Cadastro.Clientes.Service.Services;
using Cadastro.Clientes.Service.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Diagnostics;

namespace Cadastro.Clientes.Api.Configuration
{
    public static class InjectDependences
    {

        public static void InjetarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlConnection(configuration);
            services.AddRepositorys();
            services.AddServices();                
        }

        private static void AddSqlConnection(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = "";

            if (!Debugger.IsAttached)
                connectionString = configuration.GetConnectionString("Production");

            else
                connectionString = configuration.GetConnectionString("Postgres");

            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            services.AddSingleton<IDbConnection>(con);
        }

        private static void AddRepositorys(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IClienteService, ClienteService>();
        }
    }
}

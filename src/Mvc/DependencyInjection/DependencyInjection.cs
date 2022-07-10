using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using Infra.Contexto;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Mvc.Models;

namespace Mvc.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=ProjetoModeloDDD;Trusted_Connection=True;";

            services.AddDbContext<ProjetoModeloContext>(options => options.UseSqlServer(connection));
        }
    }
}

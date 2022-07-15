using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Services;
using Infra.Contexto;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mvc.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddDbContext<ProjetoModeloContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlDatabase")));
        }
    }
}

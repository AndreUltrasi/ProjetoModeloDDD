using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;
using Core.UseCases;
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
            services.AddScoped<IProdutoUseCase, ProdutoUseCase>();
            services.AddScoped<IClienteUseCase, ClienteUseCase>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddDbContext<ProjetoModeloContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlDatabase")));
        }
    }
}

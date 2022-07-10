using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Core.Interfaces.Repositories;
using ProjetoModeloDDD.Core.Interfaces.Services;
using ProjetoModeloDDD.Core.Services;
using ProjetoModeloDDD.Infra.Contexto;
using ProjetoModeloDDD.Infra.Repositories;

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

            
            services.AddDbContext<ProjetoModeloContext>();
        }
    }
}

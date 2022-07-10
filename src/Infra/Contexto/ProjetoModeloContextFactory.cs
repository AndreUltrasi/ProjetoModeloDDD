using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Infra.Contexto;
public class BloggingContextFactory : IDesignTimeDbContextFactory<ProjetoModeloContext>
{
    public ProjetoModeloContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ProjetoModeloContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlDatabase"));

        return new ProjetoModeloContext(optionsBuilder.Options);
    }
}
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class BloggingContextFactory : IDesignTimeDbContextFactory<ProjetoModeloContext>
{
    public ProjetoModeloContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .Build();

        var connectionString = configuration.GetConnectionString("SqlDatabase");

        var optionsBuilder = new DbContextOptionsBuilder<ProjetoModeloContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ProjetoModeloContext(optionsBuilder.Options);
    }
}
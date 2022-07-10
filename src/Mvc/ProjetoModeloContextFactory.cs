using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class BloggingContextFactory : IDesignTimeDbContextFactory<ProjetoModeloContext>
{
    public ProjetoModeloContext CreateDbContext(string[] args)
    {
        var connection = @"Server=(localdb)\mssqllocaldb;Database=ProjetoModeloDDD;Trusted_Connection=True;";
        var optionsBuilder = new DbContextOptionsBuilder<ProjetoModeloContext>();
        optionsBuilder.UseSqlServer(connection);

        return new ProjetoModeloContext(optionsBuilder.Options);
    }
}
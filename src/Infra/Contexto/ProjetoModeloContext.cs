using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexto
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext(DbContextOptions options)
           : base(options)
        { }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connection = @"Server=(localdb)\mssqllocaldb;Database=ProjetoModeloDDD;Trusted_Connection=True;";
        //    optionsBuilder.UseSqlServer(connection);
        //}
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Produto>? Produtos { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Core.Domain.Entities;
namespace ProjetoModeloDDD.Infra.Contexto
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext(DbContextOptions<ProjetoModeloContext> options)
           : base(options)
        { }

        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Produto>? Produtos { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        //    modelBuilder.Properties()
        //        .Where(p => p.Name == p.ReflectedType.Name + "Id")
        //        .Configure(p => p.IsKey());

        //    modelBuilder.Properties<string>()
        //        .Configure(p => p.HasColumnType("varchar"));

        //    modelBuilder.Properties<string>()
        //        .Configure(p => p.HasMaxLength(100));

        //    modelBuilder.Configurations.Add(new ClienteConfiguration());
        //    modelBuilder.Configurations.Add(new ProdutoConfiguration());

        //    Database.SetInitializer<ProjetoModeloContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}

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

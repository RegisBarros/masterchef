using Fiap.Masterchef.Core;
using Fiap.Masterchef.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Masterchef.Infra.Data.Contexts
{
    public class MasterchefContext : DbContext
    {
        public MasterchefContext(DbContextOptions<MasterchefContext> options)
            :base(options)
        { }
        public DbSet<Receita> Receitas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ReceitaMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }
    }
}
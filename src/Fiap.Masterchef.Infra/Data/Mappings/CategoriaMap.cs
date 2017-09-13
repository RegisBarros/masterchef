using Fiap.Masterchef.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.Masterchef.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.Descricao)
               .HasMaxLength(150)
               .IsRequired();

            builder.HasMany(r => r.Receitas)
                .WithOne(r => r.Categoria)
                .IsRequired();
        }
    }
}
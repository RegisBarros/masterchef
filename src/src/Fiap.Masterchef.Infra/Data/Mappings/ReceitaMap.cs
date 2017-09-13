using Fiap.Masterchef.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.Masterchef.Infra.Data.Mappings
{
    public class ReceitaMap : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.ToTable("Receita");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.Descricao)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(r => r.Ingredientes)
               .HasMaxLength(500)
               .IsRequired();

            builder.Property(r => r.Preparo)
               .HasMaxLength(1000)
               .IsRequired();

            builder.Property(r => r.Foto)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(r => r.Tags)
               .HasMaxLength(200);

            builder.Property(r => r.Favorita)
               .IsRequired();

            builder.Property(r => r.TempoPreparo)
               .IsRequired();

            builder.Property(r => r.CategoriaId)
               .IsRequired();

            builder.HasOne(r => r.Categoria)
                .WithMany(r => r.Receitas);
        }
    }
}

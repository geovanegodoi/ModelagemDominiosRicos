using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

            // 1:N => Categoria : Produtos
            builder.HasMany(c => c.Produtos)
                   .WithOne(p=>p.Categoria)
                   .HasForeignKey(p => p.CategoriaId);

            builder.ToTable("Categorias");
        }
    }
}

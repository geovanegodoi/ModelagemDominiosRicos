using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

            builder.Property(p => p.Descricao)
                   .HasColumnType("varchar(500)")
                   .IsRequired();

            builder.Property(p => p.Imagem)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

            builder.OwnsOne(p => p.Dimensoes, child =>
            {
                child.Property(d => d.Altura)
                     .HasColumnName("Altura")
                     .HasColumnType("int");

                child.Property(c => c.Largura)
                     .HasColumnName("Largura")
                     .HasColumnType("int");

                child.Property(c => c.Profundidade)
                     .HasColumnName("Profundidade")
                     .HasColumnType("int");
            });

            builder.ToTable("Produtos");
        }
    }
}

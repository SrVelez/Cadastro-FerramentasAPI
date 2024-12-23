using Cadastro_de_Ferramentas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro_de_Ferramentas.Context.Mappings
{
    public class FerramentaMapping : IEntityTypeConfiguration<Ferramenta>
    {
        public void Configure(EntityTypeBuilder<Ferramenta> builder)
        {
            builder.ToTable("Ferramenta");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.NomeDaFerramenta)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(f => f.Quantidade)
                .IsRequired(true)
                .HasColumnType("INT")
                .HasMaxLength(10);

            builder.Property(f => f.Descricao)
               .IsRequired(false)
               .HasColumnType("TEXT")
               .HasMaxLength(200);

            builder.Property(f => f.DataPedido)
                .IsRequired(true)
                .HasColumnType("DATE")
                .HasMaxLength(255);

        }
    }
}

using Cadastro_de_Ferramentas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro_de_Ferramentas.Context.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
                builder.ToTable("Cliente");

                builder.HasKey(c => c.Id);

                builder.Property(c => c.Nome)
                    .IsRequired(true)
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(80);

                builder.Property(c => c.CPF)
                    .IsRequired(true)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(18);

                builder.Property(c => c.Email)
                    .IsRequired(true)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(100);

                builder.Property(c => c.Phone)
                   .IsRequired(true)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(14);

                builder.Property(c => c.Address)
                   .IsRequired(true)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(150);
            
        }
    }
}

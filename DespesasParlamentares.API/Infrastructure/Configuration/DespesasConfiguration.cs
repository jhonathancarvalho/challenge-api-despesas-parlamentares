using DespesasParlamentares.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesasParlamentares.API.Infrastructure.Configuration
{
    public class DespesasConfiguration : IEntityTypeConfiguration<Despesas>
    {
        public void Configure(EntityTypeBuilder<Despesas> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Fornecedor).IsRequired().HasMaxLength(100);
            builder.Property(d => d.ValorLiquido).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(d => d.UrlNotaFiscal).HasMaxLength(255);
            builder.Property(d => d.DataEmissao).IsRequired();

            builder.HasOne(d => d.Deputado)
                   .WithMany(dp => dp.Despesas)
                   .HasForeignKey(d => d.DeputadoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
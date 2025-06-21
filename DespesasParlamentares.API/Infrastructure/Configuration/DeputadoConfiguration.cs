using DespesasParlamentares.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespesasParlamentares.API.Infrastructure.Configuration
{
    public class DeputadoConfiguration : IEntityTypeConfiguration<Deputado>
    {
        public void Configure(EntityTypeBuilder<Deputado> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Nome).IsRequired().HasMaxLength(100);
            builder.Property(d => d.UnidadeFederativa).IsRequired().HasMaxLength(2);
            builder.Property(d => d.CPF).IsRequired().HasMaxLength(11);
            builder.Property(d => d.PartidoPolitico).IsRequired().HasMaxLength(50);
        }
    }
}
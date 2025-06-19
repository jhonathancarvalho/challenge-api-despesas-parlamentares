using DespesasParlamentares.API.Infrastructure.Configuration;
using DespesasParlamentares.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DespesasParlamentares.API.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Despesas> Despesas { get; set; }
        public DbSet<Deputado> Deputados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DeputadoConfiguration());
            modelBuilder.ApplyConfiguration(new DespesasConfiguration());
        }
    }
}

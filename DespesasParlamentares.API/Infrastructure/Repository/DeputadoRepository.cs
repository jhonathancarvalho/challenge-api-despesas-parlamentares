using DespesasParlamentares.API.Infrastructure.Context;
using DespesasParlamentares.API.Infrastructure.Repository.Interfaces;
using DespesasParlamentares.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DespesasParlamentares.API.Infrastructure.Repository
{
    public class DeputadoRepository : IDeputadoRepository
    {
        private readonly ApplicationDbContext _context;
        public DeputadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Deputado>> ListarDeputadosPorEstadoAsync(string unidadeFederativa)
        {
            return await _context.Deputados.Where(x => x.UnidadeFederativa.Equals(unidadeFederativa.ToUpper()))
                .ToListAsync();
        }

        public async Task<Deputado?> ObterDeputadoComDespesaPorEstadoAsync(string unidadeFederativa, Guid id)
        {
            return await _context.Deputados.Include(x => x.Despesas).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AdicionarBaseDadosDeputado(List<Deputado> deputado)
        {
            await _context.Deputados.AddRangeAsync(deputado);
            await _context.SaveChangesAsync();

        }

        public async Task AdicionarBaseDadosDespesas(List<Despesas> despesas)
        {
            await _context.Despesas.AddRangeAsync(despesas);
            await _context.SaveChangesAsync();
        }
    }
}

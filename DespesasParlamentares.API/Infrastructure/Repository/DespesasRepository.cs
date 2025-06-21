using DespesasParlamentares.API.Infrastructure.Context;
using DespesasParlamentares.API.Infrastructure.Repository.Interfaces;
using DespesasParlamentares.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DespesasParlamentares.API.Infrastructure.Repository
{
    public class DespesasRepository : IDespesasRepository
    {
        private readonly ApplicationDbContext _context;

        public DespesasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Despesas>> ObterDespesasPorEstadoAsync(string unidadeFederativa)
        {
            return await _context.Despesas
                .Include(d => d.Deputado)
                .Where(d => d.Deputado.UnidadeFederativa.ToUpper() == unidadeFederativa.ToUpper())
                .ToListAsync();
        }

        public async Task<List<Despesas>> ObterDespesasPorDeputadoAsync(Guid deputadoId)
        {
            return await _context.Despesas
                .Where(d => d.DeputadoId == deputadoId)
                .ToListAsync();
        }

        public async Task AdicionarDespesasAsync(List<Despesas> despesas)
        {
            await _context.Despesas.AddRangeAsync(despesas);
        }
    }
}
using DespesasParlamentares.API.Infrastructure.Context;
using DespesasParlamentares.API.Infrastructure.Repository.Interfaces;
using DespesasParlamentares.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DespesasParlamentares.API.Infrastructure.Repository
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly ApplicationDbContext _context;
        public DespesaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Despesas>> ObterTotalDespesasPorEstadoAsync(string unidadeFederativa)
        {
            return await _context.Despesas
                .Where(d => d.Deputado.UnidadeFederativa.Equals(unidadeFederativa.ToUpper()))
                .ToListAsync();
        }
    }
}

using DespesasParlamentares.API.Models.Entities;

namespace DespesasParlamentares.API.Infrastructure.Repository.Interfaces
{
    public interface IDespesaRepository
    {
        Task<List<Despesas>> ObterTotalDespesasPorEstadoAsync(string unidadeFederativa);
    }
}

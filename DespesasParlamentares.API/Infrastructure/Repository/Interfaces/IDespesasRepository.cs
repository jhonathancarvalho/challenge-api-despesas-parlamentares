using DespesasParlamentares.API.Models.Entities;

namespace DespesasParlamentares.API.Infrastructure.Repository.Interfaces
{
    public interface IDespesasRepository
    {
        Task<List<Despesas>> ObterDespesasPorEstadoAsync(string unidadeFederativa);
        Task<List<Despesas>> ObterDespesasPorDeputadoAsync(Guid deputadoId);
        Task AdicionarDespesasAsync(List<Despesas> despesas);
    }
}
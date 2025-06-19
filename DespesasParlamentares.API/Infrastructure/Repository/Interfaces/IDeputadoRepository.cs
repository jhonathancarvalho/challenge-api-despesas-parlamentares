using DespesasParlamentares.API.Models.Entities;

namespace DespesasParlamentares.API.Infrastructure.Repository.Interfaces
{
    public interface IDeputadoRepository
    {
        Task<List<Deputado>> ListarDeputadosPorEstadoAsync(string uf);
        Task<Deputado?> ObterDeputadoComDespesaPorEstadoAsync(string uf, Guid id);
        Task AdicionarBaseDadosDeputado(List<Deputado> deputados);
        Task AdicionarBaseDadosDespesas(List<Despesas> despesas);
    }
}

using DespesasParlamentares.API.Models.Entities.DTOs;

namespace DespesasParlamentares.API.Implementation.Interface
{
    public interface IDeputadoServices
    {
        Task<List<DeputadoDTO>> ListarDeputadosPorEstadoAsync(string uf);

        Task<DeputadoComDespesaDTO> ObterDeputadoComDespesasAsync(string uf, Guid id);

        Task<DespesasPorEstadoDTO> ObterDespesaPorEstadoAsync(string unidadeFederativa);
    }
}

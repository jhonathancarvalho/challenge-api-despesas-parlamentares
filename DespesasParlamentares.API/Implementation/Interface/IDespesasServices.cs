using DespesasParlamentares.API.Models.Entities;
using DespesasParlamentares.API.Models.Entities.DTOs;

namespace DespesasParlamentares.API.Implementation.Interface
{
    public interface IDespesasServices
    {
        Task<List<DespesasDTO>> ObterDespesasPorDeputadoAsync(Guid deputadoId);
        Task<DespesasPorEstadoDTO> ObterDespesasPorEstadoAsync(string unidadeFederativa);
    }
}
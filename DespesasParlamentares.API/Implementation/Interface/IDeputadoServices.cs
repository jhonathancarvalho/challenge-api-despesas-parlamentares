using DespesasParlamentares.API.Models.Entities.DTOs;

namespace DespesasParlamentares.API.Implementation.Interface
{
    public interface IDeputadoServices
    {
        Task<List<DeputadoDTO>> ListarDeputadosPorEstadoAsync(string unidadeFederativa);

        Task<DeputadoComDespesaDTO> ObterDeputadoComDespesasAsync(string unidadeFederativa, Guid id);


    }
}

using DespesasParlamentares.API.Implementation.Interface;
using DespesasParlamentares.API.Infrastructure.Repository.Interfaces;
using DespesasParlamentares.API.Mappers;
using DespesasParlamentares.API.Models.Entities.DTOs;

namespace DespesasParlamentares.API.Implementation.Services
{
    public class DeputadoServices : IDeputadoServices
    {
        private readonly IDeputadoRepository _deputadoRepository;
        private readonly IDespesasRepository _despesasRepository;

        public DeputadoServices(IDeputadoRepository deputadoRepository, IDespesasRepository despesaRepository)
        {
            _deputadoRepository = deputadoRepository;
            _despesasRepository = despesaRepository;
        }

        public async Task<List<DeputadoDTO>> ListarDeputadosPorEstadoAsync(string unidadeFederativa)
        {
            var deputados = await _deputadoRepository.ListarDeputadosPorEstadoAsync(unidadeFederativa);

            return deputados.MapearParaListaDto();
        }

        public async Task<DeputadoComDespesaDTO> ObterDeputadoComDespesasAsync(string unidadeFederativa, Guid id)
        {
            var deputado = await _deputadoRepository.ObterDeputadoComDespesaPorEstadoAsync(unidadeFederativa, id);

            return deputado is null ? null : deputado.MapearParaDto();

        }
    }
}

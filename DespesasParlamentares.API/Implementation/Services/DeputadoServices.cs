using DespesasParlamentares.API.Implementation.Interface;
using DespesasParlamentares.API.Infrastructure.Repository.Interfaces;
using DespesasParlamentares.API.Mappers;
using DespesasParlamentares.API.Models.Entities.DTOs;

namespace DespesasParlamentares.API.Implementation.Services
{
    public class DeputadoServices : IDeputadoServices
    {
        private readonly IDeputadoRepository _deputadoRepository;
        private readonly IDespesaRepository _despesaRepository;

        public DeputadoServices(IDeputadoRepository deputadoRepository, IDespesaRepository despesaRepository)
        {
            _deputadoRepository = deputadoRepository;
            _despesaRepository = despesaRepository;
        }

        public async Task<List<DeputadoDTO>> ListarDeputadosPorEstadoAsync(string uf)
        {
            var deputados = await _deputadoRepository.ListarDeputadosPorEstadoAsync(uf);

            return deputados.MapearParaListaDto();
        }

        public async Task<DeputadoComDespesaDTO> ObterDeputadoComDespesasAsync(string uf, Guid id)
        {
            var deputado = await _deputadoRepository.ObterDeputadoComDespesaPorEstadoAsync(uf, id);

            return deputado is null ? null : deputado.MapearParaDto();

        }

        public async Task<DespesasPorEstadoDTO> ObterDespesaPorEstadoAsync(string unidadeFederativa)
        {
            var despesas = await _despesaRepository.ObterTotalDespesasPorEstadoAsync(unidadeFederativa);

            return despesas.MapearParaDto();

        }
    }
}

using DespesasParlamentares.API.Implementation.Interface;
using DespesasParlamentares.API.Infrastructure.Repository.Interfaces;
using DespesasParlamentares.API.Mappers;
using DespesasParlamentares.API.Models.Entities.DTOs;
using System.Globalization;

public class DespesasServices : IDespesasServices
{
    private readonly IDespesasRepository _despesasRepository;

    public DespesasServices(IDespesasRepository despesasRepository)
    {
        _despesasRepository = despesasRepository ?? throw new ArgumentNullException(nameof(despesasRepository));
    }

    public async Task<List<DespesasDTO>> ObterDespesasPorDeputadoAsync(Guid deputadoId)
    {
        if (deputadoId == Guid.Empty)
            throw new ArgumentException("Id do deputado inválido.", nameof(deputadoId));

        var despesas = await _despesasRepository.ObterDespesasPorDeputadoAsync(deputadoId);

        if (despesas == null || !despesas.Any())
            return new List<DespesasDTO>();

        return despesas.Select(d => d.MapearParaDespesasDto()).ToList();
    }

    public async Task<DespesasPorEstadoDTO> ObterDespesasPorEstadoAsync(string unidadeFederativa)
    {
        if (string.IsNullOrWhiteSpace(unidadeFederativa))
            throw new ArgumentException("Unidade federativa não pode ser vazia.", nameof(unidadeFederativa));

        var despesas = await _despesasRepository.ObterDespesasPorEstadoAsync(unidadeFederativa);

        if (despesas == null || !despesas.Any())
            return new DespesasPorEstadoDTO("0.00");

        return despesas.MapearParaResumoEstadoDto();
    }
}

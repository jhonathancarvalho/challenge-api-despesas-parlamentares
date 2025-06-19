using DespesasParlamentares.API.Models.Entities;
using DespesasParlamentares.API.Models.Entities.DTOs;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace DespesasParlamentares.API.Mappers
{
    public static class DespesasMapper
    {
        public static DespesasPorEstadoDTO MapearParaDto(this List<Despesas> despesas)
        {
            var totalDespesas = despesas.Sum(x => x.ValorLiquido)
                .ToString("C", new CultureInfo(name: "pt-BR"));

            return despesas
                .Select(d => new DespesasPorEstadoDTO(totalDespesas))
                .FirstOrDefault();
        }
    }
}

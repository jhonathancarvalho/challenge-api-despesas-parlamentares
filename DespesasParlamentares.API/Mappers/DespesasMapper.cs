using DespesasParlamentares.API.Models.Entities;
using DespesasParlamentares.API.Models.Entities.DTOs;
using System.Globalization;

namespace DespesasParlamentares.API.Mappers
{
    public static class DespesasMapper
    {
        public static DespesasDTO MapearParaDespesasDto(this Despesas despesa)
        {
            return new DespesasDTO(
                despesa.DataEmissao.ToString("yyyy-MM-dd"),
                despesa.Fornecedor,
                despesa.ValorLiquido.ToString("N2", new CultureInfo("pt-BR")),
                despesa.UrlNotaFiscal
            );
        }

        public static DespesasPorEstadoDTO MapearParaResumoEstadoDto(this List<Despesas> despesas)
        {
            var total = despesas.Sum(d => d.ValorLiquido);
            return new DespesasPorEstadoDTO(total.ToString("N2", new CultureInfo("pt-BR")));
        }
    }
}
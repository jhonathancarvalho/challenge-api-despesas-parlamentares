using DespesasParlamentares.API.Models.Entities;
using DespesasParlamentares.API.Models.Entities.DTOs;
using System.Globalization;

namespace DespesasParlamentares.API.Mappers
{
    public static class DeputadoMapper
    {
        public static List<DeputadoDTO> MapearParaListaDto(this List<Deputado> deputado)
        {
            return deputado.Select(dep => new DeputadoDTO(
                dep.Id,
                dep.Nome,
                dep.CPF,
                dep.UnidadeFederativa,
                dep.PartidoPolitico))
                .ToList();
        }

        public static DeputadoComDespesaDTO MapearParaDto(this Deputado deputado)
        {
            var despesas = deputado.Despesas
                .OrderByDescending(x => x.ValorLiquido)
                .Select(despesa => new DespesasDTO(
                    despesa.DataEmissao.ToString("dd/MM/yyyy"),
                    despesa.Fornecedor,
                    despesa.ValorLiquido.ToString("C", new CultureInfo("pt-BR")),
                    despesa.UrlNotaFiscal))
                .ToList();

            var totalDespesas = deputado.Despesas
                .Sum(x => x.ValorLiquido)
                .ToString("C", new CultureInfo("pt-BR"));

            return new DeputadoComDespesaDTO(
               TotalDespesas: totalDespesas,
               Id: deputado.Id,
               Nome: deputado.Nome,
               Uf: deputado.UnidadeFederativa,
               Cpf: deputado.CPF,
               PartidoPolitico: deputado.PartidoPolitico,
               Despesas: despesas
           );
        }
    }
}
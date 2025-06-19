using DespesasParlamentares.API.Models.Common;

namespace DespesasParlamentares.API.Models.Entities
{
    public class Despesas : BaseEntity
    {
        public Guid DeputadoId { get; private set; }
        public Deputado Deputado { get; private set; }

        public DateTimeOffset DataEmissao { get; private set; }
        public string Fornecedor { get; private set; }
        public decimal ValorLiquido { get; private set; }
        public string UrlNotaFiscal { get; private set; }

        public Despesas(Guid deputadoId, DateTimeOffset dataEmissao, string fornecedor, decimal valorLiquido, string urlDocumento)
        {
            Validar(deputadoId, dataEmissao, fornecedor, valorLiquido, urlDocumento);

            DeputadoId = deputadoId;
            DataEmissao = dataEmissao;
            Fornecedor = fornecedor;
            ValorLiquido = valorLiquido;
            UrlNotaFiscal = urlDocumento;
        }

        private void Validar(Guid deputadoId, DateTimeOffset dataEmissao, string fornecedor, decimal valorLiquido, string urlDocumento)
        {
            var erros = new List<string>();

            if (deputadoId == Guid.Empty)
                erros.Add("O ID do deputado é obrigatório.");

            if (dataEmissao > DateTimeOffset.UtcNow)
                erros.Add("A data de emissão não pode ser no futuro.");

            if (string.IsNullOrWhiteSpace(fornecedor))
                erros.Add("O nome do fornecedor é obrigatório.");

            if (valorLiquido < 0)
                erros.Add("O valor líquido não pode ser negativo.");

            if (string.IsNullOrWhiteSpace(urlDocumento))
                erros.Add("A URL da nota fiscal é obrigatória.");

            if (erros.Any())
                throw new ArgumentException(string.Join(" ", erros));

        }

        private Despesas() { }
    }
}
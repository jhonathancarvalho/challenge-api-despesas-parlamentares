using CsvHelper;
using CsvHelper.Configuration;
using DespesasParlamentares.API.Implementation.Interface;
using DespesasParlamentares.API.Infrastructure.Repository.Interfaces;
using DespesasParlamentares.API.Models.Entities;
using System.Globalization;

namespace DespesasParlamentares.API.Implementation.Services
{
    public class BaseDadosServices : IBaseDadosServices
    {

        private readonly IDeputadoRepository _deputadoRepository;

        public BaseDadosServices(IDeputadoRepository deputadoRepository)
        {
            _deputadoRepository = deputadoRepository;
        }

        public async Task CarregarBaseDados(string path, string uf)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true,
                MissingFieldFound = null
            });

            await csv.ReadAsync();
            csv.ReadHeader();

            var despesas = new List<Despesas>();
            var deputados = new Dictionary<int, Deputado>();

            try
            {
                while (await csv.ReadAsync())
                {
                    if (string.IsNullOrWhiteSpace(csv.GetField("ideCadastro")))
                        continue;

                    int deputadoId = int.Parse(csv.GetField("ideCadastro"));

                    if (!deputados.ContainsKey(deputadoId))
                    {
                        var deputado = new Deputado(
                            nome: csv.GetField("txNomeParlamentar"),
                            unidadeFederativa: csv.GetField("sgUF"),
                            cpf: csv.GetField("cpf"),
                            partidoPolitico: csv.GetField("sgPartido")
                        );

                        deputados.Add(deputadoId, deputado);
                    }


                    if (!DateTimeOffset.TryParse(csv.GetField("datEmissao"), out var dataEmissao))
                        continue;

                    if (!decimal.TryParse(csv.GetField("vlrLiquido"), out var valorLiquido))
                        continue;

                    Guid deputadoGuid = deputados[deputadoId].Id;

                    var urlDocumento = csv.GetField("urlDocumento");

                    if (string.IsNullOrWhiteSpace(urlDocumento))
                        continue;

                    despesas.Add(new Despesas(
                        deputadoGuid,
                        dataEmissao: dataEmissao,
                        fornecedor: csv.GetField("txtFornecedor"),
                        valorLiquido: valorLiquido,
                        urlDocumento: urlDocumento
                    ));
                }


                await _deputadoRepository.AdicionarBaseDadosDeputado(deputados.Values.ToList());
                await _deputadoRepository.AdicionarBaseDadosDespesas(despesas);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao carregar dados: {e.Message}");
                throw;
            }
        }
    }
}
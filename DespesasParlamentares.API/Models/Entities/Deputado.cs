using DespesasParlamentares.API.Models.Common;

namespace DespesasParlamentares.API.Models.Entities
{
    public class Deputado : BaseEntity
    {
        public string Nome { get; private set; }
        public string UnidadeFederativa { get; private set; }
        public string CPF { get; private set; }
        public string PartidoPolitico { get; private set; }

        public ICollection<Despesas> Despesas { get; private set; } = new List<Despesas>();

        public Deputado(string nome, string unidadeFederativa, string cpf, string partidoPolitico)
        {
            Validar(nome, unidadeFederativa, cpf, partidoPolitico);

            Nome = nome;
            UnidadeFederativa = unidadeFederativa;
            CPF = cpf;
            PartidoPolitico = partidoPolitico;
        }

        private void Validar(string nome, string uf, string cpf, string partido)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(nome))
                erros.Add("O nome do deputado é obrigatório.");

            if (string.IsNullOrWhiteSpace(uf) || uf.Length != 2)
                erros.Add("A unidade federativa (UF) é obrigatória e deve conter 2 letras.");

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
                erros.Add("O CPF é obrigatório, deve conter exatamente 11 dígitos numéricos.");

            if (string.IsNullOrWhiteSpace(partido))
                erros.Add("O partido político é obrigatório.");

            if (erros.Any())
                throw new ArgumentException(string.Join(" ", erros));
        }
        private Deputado() { }
    }
}
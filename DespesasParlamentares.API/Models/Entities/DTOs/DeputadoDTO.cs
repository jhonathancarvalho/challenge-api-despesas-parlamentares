namespace DespesasParlamentares.API.Models.Entities.DTOs
{
    public record DeputadoDTO(Guid Id, string nome, string unidadeFederativa, string cpf, string partidoPolitico);
}

namespace DespesasParlamentares.API.Models.Entities.DTOs
{
    public record DeputadoComDespesaDTO(
        string TotalDespesas,
        Guid Id,
        string Nome,
        string Uf,
        string Cpf,
        string PartidoPolitico,
        List<DespesasDTO> Despesas
    );
}
namespace DespesasParlamentares.API.Implementation.Interface
{
    public interface IBaseDadosServices
    {
        Task CarregarBaseDados(string filePath, string uf);
    }
}

namespace DespesasParlamentares.API.Models.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; }
        public DateTimeOffset DataCriacao { get; protected set; }
        public DateTimeOffset? DataAtualizacao { get; protected set; }
        public DateTimeOffset? DataExclusao { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTimeOffset.UtcNow;
        }

        public void MarcarComoAtualizado()
        {
            DataAtualizacao = DateTimeOffset.UtcNow;
        }

        public void MarcarComoExcluido()
        {
            DataExclusao = DateTimeOffset.UtcNow;
        }
    }
}
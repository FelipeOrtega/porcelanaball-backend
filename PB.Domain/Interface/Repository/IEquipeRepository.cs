namespace PB.Domain.Interface.Repository
{
    public interface IEquipeRepository : IRepositoryBase<Equipe>
    {
        public Equipe SearchByDescription(string descricao);
    }
}

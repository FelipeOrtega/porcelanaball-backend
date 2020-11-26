namespace PB.Domain.Interface.Repository
{
    public interface IPlanoRepository : IRepositoryBase<Plano>
    {
        public Plano ConsultaPorDescricao(string descricao);
    }
}

namespace PB.Domain.Interface.Repository
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        Aluno SelecionarPorCpf(Aluno aluno);

    }
}

namespace PB.Domain.Interface.Repository
{
    public interface IFuncionarioRepository : IRepositoryBase<Funcionario>
    {
        public Funcionario SearchCpf(string cpf);
    }
}
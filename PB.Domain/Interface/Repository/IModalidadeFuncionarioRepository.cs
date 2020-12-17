namespace PB.Domain.Interface.Repository
{
    public interface IModalidadeFuncionarioRepository : IRepositoryBase<ModalidadeFuncionario>
    {
        public ModalidadeFuncionario ModalidadeFuncionarioExist(int funcionario_codigo, int modalidade_codigo);
    }
}

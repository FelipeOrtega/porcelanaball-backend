namespace PB.Domain.Interface.Repository
{
    public interface IModalidadeFuncionarioRepository : IRepositoryBase<ModalidadeFuncionario>
    {
        public ModalidadeFuncionario ModalidadeFuncionarioExiste(int funcionario_codigo, int modalidade_codigo);
    }
}

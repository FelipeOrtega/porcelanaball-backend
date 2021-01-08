namespace PB.Domain.Interface.Repository
{
    public interface IFuncionarioModalidadeRepository : IRepositoryBase<FuncionarioModalidade>
    {
        public FuncionarioModalidade ModalidadeFuncionarioExist(int funcionario_codigo, int modalidade_codigo);
    }
}

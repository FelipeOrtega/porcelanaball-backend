namespace PB.Domain.Interface.Repository
{
    public interface IProdutoCategoriaRepository : IRepositoryBase<ProdutoCategoria>
    {
        public ProdutoCategoria ConsultaPorDescricao(string descricao);
    }
}

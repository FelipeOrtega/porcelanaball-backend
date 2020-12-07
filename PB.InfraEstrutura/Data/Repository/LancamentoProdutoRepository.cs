using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class LancamentoProdutoRepository : RepositoryBase<LancamentoProduto>, ILancamentoProdutoRepository
    {
        public LancamentoProdutoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

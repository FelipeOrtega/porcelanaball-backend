using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class ProdutoLoteRepository : RepositoryBase<ProdutoLote>, IProdutoLoteRepository
    {
        public ProdutoLoteRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDBContext context) : base(context)
        {
        }

        public Produto SearchByDescription(string descricao)
        {
            return context.Set<Produto>().Where(x => x.descricao == descricao).FirstOrDefault();
        }
    }
}

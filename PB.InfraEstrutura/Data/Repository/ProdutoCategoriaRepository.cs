using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class ProdutoCategoriaRepository : RepositoryBase<ProdutoCategoria>, IProdutoCategoriaRepository
    {
        public ProdutoCategoriaRepository(ApplicationDBContext context) : base(context)
        {
        }

        public ProdutoCategoria SearchByDescription(string descricao)
        {
            return context.Set<ProdutoCategoria>().Where(x => x.descricao == descricao).FirstOrDefault();
        }
    }
}

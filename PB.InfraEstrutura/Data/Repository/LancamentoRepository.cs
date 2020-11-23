using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class LancamentoRepository : RepositoryBase<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

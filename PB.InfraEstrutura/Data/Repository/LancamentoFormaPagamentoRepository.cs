using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class LancamentoFormaPagamentoRepository : RepositoryBase<LancamentoFormaPagamento>, ILancamentoFormaPagamentoRepository
    {
        public LancamentoFormaPagamentoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

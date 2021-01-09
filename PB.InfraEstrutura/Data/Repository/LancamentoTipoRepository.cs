using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class LancamentoTipoRepository : RepositoryBase<LancamentoTipo>, ILancamentoTipoRepository
    {
        public LancamentoTipoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

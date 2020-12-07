using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class FormaPagamentoRepository : RepositoryBase<FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

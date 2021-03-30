using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Collections.Generic;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class PagamentoRepository : RepositoryBase<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(ApplicationDBContext context) : base(context)
        {
        }

        public List<Pagamento> SearchCodigo_Equipe(int codigoEquipe)
        {
            List<Pagamento> pagamentosByEquipe = context.Set<Pagamento>().Where(p => p.equipe_codigo == codigoEquipe).ToList();
            return pagamentosByEquipe;
        }
    }
}

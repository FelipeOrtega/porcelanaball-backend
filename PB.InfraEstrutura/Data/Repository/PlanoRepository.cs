using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>, IPlanoRepository
    {
        public PlanoRepository(ApplicationDBContext context) : base(context)
        {
        }

        public Plano ConsultaPorDescricao(string descricao)
        {
            return context.Set<Plano>().Where(x => x.descricao == descricao).FirstOrDefault();
        }
    }
}

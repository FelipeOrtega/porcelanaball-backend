using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>, IPlanoRepository
    {
        public PlanoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

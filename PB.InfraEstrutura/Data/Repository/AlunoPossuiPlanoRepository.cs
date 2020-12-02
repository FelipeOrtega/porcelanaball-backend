using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class AlunoPossuiPlanoRepository : RepositoryBase<AlunoPossuiPlano>, IAlunoPossuiPlanoRepository
    {
        public AlunoPossuiPlanoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

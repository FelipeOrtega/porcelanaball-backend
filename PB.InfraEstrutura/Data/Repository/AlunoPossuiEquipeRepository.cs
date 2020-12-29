using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class AlunoPossuiEquipeRepository : RepositoryBase<AlunoPossuiEquipe>, IAlunoPossuiEquipeRepository
    {
        public AlunoPossuiEquipeRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

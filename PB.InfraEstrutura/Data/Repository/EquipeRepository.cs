using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class EquipeRepository : RepositoryBase<Equipe>, IEquipeRepository
    {
        public EquipeRepository(ApplicationDBContext context) : base(context)
        {
        }

        public Equipe SearchByDescription(string descricao)
        {
            return context.Set<Equipe>().Where(x => x.descricao == descricao).FirstOrDefault();
        }
    }
}

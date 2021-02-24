using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class QuadraRepository : RepositoryBase<Quadra>, IQuadraRepository
    {
        public QuadraRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

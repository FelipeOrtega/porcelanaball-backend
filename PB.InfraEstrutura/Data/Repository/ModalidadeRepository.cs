using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class ModalidadeRepository : RepositoryBase<Modalidade>, IModalidadeRepository
    {
        public ModalidadeRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

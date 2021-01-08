using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class EquipeAlunoRepository : RepositoryBase<EquipeAluno>, IEquipeAlunoRepository
    {
        public EquipeAlunoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

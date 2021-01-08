using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class PlanoAlunoRepository : RepositoryBase<PlanoAluno>, IPlanoAlunoRepository
    {
        public PlanoAlunoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

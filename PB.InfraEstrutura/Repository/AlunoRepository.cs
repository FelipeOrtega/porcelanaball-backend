using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.db.config;

namespace PB.InfraEstrutura.Repository
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDBContext context) : base(context)
        {
        }

    }
}

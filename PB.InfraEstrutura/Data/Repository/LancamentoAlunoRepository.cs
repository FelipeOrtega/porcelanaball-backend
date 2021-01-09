using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class LancamentoAlunoRepository : RepositoryBase<LancamentoAluno>, ILancamentoAlunoRepository
    {
        public LancamentoAlunoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

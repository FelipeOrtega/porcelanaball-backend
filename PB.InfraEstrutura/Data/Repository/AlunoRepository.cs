using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {

        public AlunoRepository(ApplicationDBContext context) : base(context)
        {
        }

        public Aluno SelecionarPorCpf(Aluno aluno_)
        {
            return context.Set<Aluno>().FirstOrDefault(aluno => aluno.cpf == aluno_.cpf);
        }
    }
}

using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PB.InfraEstrutura.Data.Repository
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDBContext context) : base(context)
        {
        }

        public Aluno ConsultaCpf(string cpf)
        {
            Aluno teste = context.Set<Aluno>().Where(x => x.cpf == cpf).FirstOrDefault();
            return teste;
        }
    }
}

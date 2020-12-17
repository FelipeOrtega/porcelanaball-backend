using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ApplicationDBContext context) : base(context)
        {
        }

        public Funcionario SearchCpf(string cpf)
        {
            Funcionario teste = context.Set<Funcionario>().Where(x => x.cpf == cpf).FirstOrDefault();
            return teste;
        }
    }
}

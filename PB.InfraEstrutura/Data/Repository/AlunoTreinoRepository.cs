using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Collections.Generic;

namespace PB.InfraEstrutura.Data.Repository
{
    public class AlunoTreinoRepository : RepositoryBase<AlunoTreino>, IAlunoTreinoRepository
    {
        public AlunoTreinoRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

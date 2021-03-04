using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Collections.Generic;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class EquipeAlunoRepository : RepositoryBase<EquipeAluno>, IEquipeAlunoRepository
    {
        public EquipeAlunoRepository(ApplicationDBContext context) : base(context)
        {
        }

        public List<EquipeAluno> GetByEquipeCodigo(int codigo)
        {
            return context.Set<EquipeAluno>().Where(x => x.equipe_codigo == codigo).ToList();
        }
    }
}

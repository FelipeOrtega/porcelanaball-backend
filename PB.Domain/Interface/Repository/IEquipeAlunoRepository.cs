using System.Collections.Generic;

namespace PB.Domain.Interface.Repository
{
    public interface IEquipeAlunoRepository : IRepositoryBase<EquipeAluno>
    {
        public List<EquipeAluno> GetByEquipeCodigo(int codigo);
    }
}

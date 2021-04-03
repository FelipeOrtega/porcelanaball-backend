using System.Collections.Generic;

namespace PB.Domain.Interface.Repository
{
    public interface IEquipeRepository : IRepositoryBase<Equipe>
    {
        public Equipe SearchByDescription(string descricao);
        public Equipe FullSearch(int codigo);
        public List<Equipe> FullList();

    }
}

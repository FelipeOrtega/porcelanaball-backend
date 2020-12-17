using System.Collections.Generic;

namespace PB.Domain.Interface.Repository
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        public Aluno SearchCpf(string cpf);
        public Aluno FullSearch(Aluno aluno);
        public List<Aluno> FullList();

    }
}

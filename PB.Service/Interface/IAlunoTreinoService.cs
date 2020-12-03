using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IAlunoTreinoService
    {
        List<AlunoTreino> Get();
        AlunoTreino Get(int codigo);
        int Insert(AlunoTreino alunoTreino);
        int Update(AlunoTreino alunoTreino);
        int Delete(AlunoTreino alunoTreino);
    }
}

using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IEquipeAlunoService
    {
        List<EquipeAluno> Get();
        EquipeAluno Get(int codigo);
        int Insert(EquipeAluno alunoPossuiEquipe);
        int Update(EquipeAluno alunoPossuiEquipe);
        int Delete(int id);
    }
}

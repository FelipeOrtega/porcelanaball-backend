using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IAlunoPossuiEquipeService
    {
        List<AlunoPossuiEquipe> Get();
        AlunoPossuiEquipe Get(int codigo);
        int Insert(AlunoPossuiEquipe alunoPossuiEquipe);
        int Update(AlunoPossuiEquipe alunoPossuiEquipe);
        int Delete(int id);
    }
}

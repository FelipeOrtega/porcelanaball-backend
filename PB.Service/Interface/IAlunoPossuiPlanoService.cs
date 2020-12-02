using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IAlunoPossuiPlanoService
    {
        List<AlunoPossuiPlano> Get();
        AlunoPossuiPlano Get(int codigo);
        int Insert(AlunoPossuiPlano alunoPossuiPlano);
        int Update(AlunoPossuiPlano alunoPossuiPlano);
        int Delete(AlunoPossuiPlano alunoPossuiPlano);
    }
}

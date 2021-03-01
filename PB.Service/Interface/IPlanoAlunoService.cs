using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IPlanoAlunoService
    {
        List<PlanoAluno> Get();
        PlanoAluno Get(int codigo);
        int Insert(PlanoAluno alunoPlano);
        int Update(PlanoAluno alunoPlano);
        int Delete(int id);
    }
}

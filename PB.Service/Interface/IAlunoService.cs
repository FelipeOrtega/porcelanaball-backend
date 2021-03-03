using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IAlunoService
    {
        List<Aluno> Get();
        Aluno Get(int codigo);
        int Insert(Aluno aluno);
        int Update(Aluno aluno);
        int Delete(int id);
    }
}

using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IModalidadeService
    {
        List<Modalidade> Get();
        Modalidade Get(int codigo);
        int Insert(Modalidade modalidade);
        int Update(Modalidade modalidade);
        int Delete(int codigo);
    }
}

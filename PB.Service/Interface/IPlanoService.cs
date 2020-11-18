using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IPlanoService
    {
        List<Plano> Get();
        Plano Get(int codigo);
        int Insert(Plano plano);
        int Update(Plano plano);
        int Delete(int codigo);
    }
}

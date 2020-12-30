using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IModuloService
    {
        List<Modulo> Get();
        Modulo Get(int codigo);
        int Insert(Modulo modulo);
        int Update(Modulo modulo);
        int Delete(int codigo);
    }
}

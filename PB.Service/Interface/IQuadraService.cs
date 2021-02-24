using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface IQuadraService
    {
        List<Quadra> Get();
        Quadra Get(int codigo);
        int Insert(Quadra quadra);
        int Update(Quadra quadra);
        int Delete(int codigo);
    }
}

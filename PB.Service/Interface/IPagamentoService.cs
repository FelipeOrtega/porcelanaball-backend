using System.Collections.Generic;
using PB.Domain;

namespace PB.Service.Interface
{
    public interface IPagamentoService
    {
        List<Pagamento> Get();
        Pagamento Get(int codigo);
        int Insert(Pagamento pagamento);
        int Update(Pagamento pagamento);
        int Delete(int id);
    }
}

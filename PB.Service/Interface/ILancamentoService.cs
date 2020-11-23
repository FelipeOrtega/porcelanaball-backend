using PB.Domain;
using System.Collections.Generic;

namespace PB.Service.Interface
{
    public interface ILancamentoService
    {
        List<Lancamento> Get();
        Lancamento Get(int codigo);
        int Insert(Lancamento modalidade);
        int Update(Lancamento modalidade);
        int Delete(Lancamento modalidade);
    }
}

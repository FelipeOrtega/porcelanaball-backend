using System.Collections.Generic;

namespace PB.Domain.Interface.Repository
{
    public interface IPagamentoRepository : IRepositoryBase<Pagamento>
    {
        public List<Pagamento> SearchCodigo_Equipe(int codigoEquipe);
    }
}

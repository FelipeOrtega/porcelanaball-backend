using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class FuncionarioModalidadeRepository : RepositoryBase<FuncionarioModalidade>, IFuncionarioModalidadeRepository
    {
        public FuncionarioModalidadeRepository(ApplicationDBContext context) : base(context)
        {
        }

        public FuncionarioModalidade ModalidadeFuncionarioExist(int funcionario_codigo, int modalidade_codigo)
        {
            return context.Set<FuncionarioModalidade>().
                Where(x => x.funcionario_codigo == funcionario_codigo && x.modalidade_codigo == modalidade_codigo).
                FirstOrDefault();
        }
    }
}

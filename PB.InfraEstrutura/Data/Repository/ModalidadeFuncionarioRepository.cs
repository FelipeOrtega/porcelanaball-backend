using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;
using System.Linq;

namespace PB.InfraEstrutura.Data.Repository
{
    public class ModalidadeFuncionarioRepository : RepositoryBase<ModalidadeFuncionario>, IModalidadeFuncionarioRepository
    {
        public ModalidadeFuncionarioRepository(ApplicationDBContext context) : base(context)
        {
        }

        public ModalidadeFuncionario ModalidadeFuncionarioExiste(int funcionario_codigo, int modalidade_codigo)
        {
            return context.Set<ModalidadeFuncionario>().
                Where(x => x.funcionario_codigo == funcionario_codigo && x.modalidade_codigo == modalidade_codigo).
                FirstOrDefault();
        }
    }
}

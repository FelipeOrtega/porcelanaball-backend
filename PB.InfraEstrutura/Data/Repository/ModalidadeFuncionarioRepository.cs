using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class ModalidadeFuncionarioRepository : RepositoryBase<ModalidadeFuncionario>, IModalidadeFuncionarioRepository
    {
        public ModalidadeFuncionarioRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

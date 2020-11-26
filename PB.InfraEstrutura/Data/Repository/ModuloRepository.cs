using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.InfraEstrutura.Data.db.config;

namespace PB.InfraEstrutura.Data.Repository
{
    public class ModuloRepository : RepositoryBase<Modulo>, IModuloRepository
    {
        public ModuloRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}

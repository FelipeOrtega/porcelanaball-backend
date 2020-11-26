using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class ModuloMap : MapBase<Modulo>
    {
        public override void Configure(EntityTypeBuilder<Modulo> builder)
        {
            base.Configure(builder);
        }
    }
}

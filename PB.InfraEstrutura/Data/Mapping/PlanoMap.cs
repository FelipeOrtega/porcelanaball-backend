using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class PlanoMap : MapBase<Plano>
    {
        public override void Configure(EntityTypeBuilder<Plano> builder)
        {
            base.Configure(builder);
        }
    }
}

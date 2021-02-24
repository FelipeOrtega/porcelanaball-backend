using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class QuadraMap : MapBase<Quadra>
    {
        public override void Configure(EntityTypeBuilder<Quadra> builder)
        {
            builder.ToTable("QUADRA");
            base.Configure(builder);
        }
    }
}

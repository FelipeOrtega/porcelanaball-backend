using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class EquipeMap : MapBase<Equipe>
    {
        public override void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("EQUIPE");
            base.Configure(builder);
        }
    }
}

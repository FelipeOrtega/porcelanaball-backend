using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class ModalidadeMap : MapBase<Modalidade>
    {
        public override void Configure(EntityTypeBuilder<Modalidade> builder)
        {
            base.Configure(builder);
        }
    }
}

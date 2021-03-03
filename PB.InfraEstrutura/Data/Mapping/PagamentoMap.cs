using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class PagamentoMap : MapBase<Pagamento>
    {
        public override void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("PAGAMENTO");
            base.Configure(builder);
        }
    }
}

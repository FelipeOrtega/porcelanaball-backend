using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class FormaPagamentoMap : MapBase<FormaPagamento>
    {
        public override void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.ToTable("FORMA_PAGAMENTO");
            base.Configure(builder);
        }
    }
}

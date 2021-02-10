using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class LancamentoFormaPagamentoMap : MapBase<LancamentoFormaPagamento>
    {
        public override void Configure(EntityTypeBuilder<LancamentoFormaPagamento> builder)
        {
            builder.HasOne(lfp => lfp.lancamento).WithMany(l => l.lancamentoFormaPagamento).HasForeignKey(lt => lt.lancamento_codigo);
            builder.ToTable("LANCAMENTO_FORMA_PAGAMENTO");
            base.Configure(builder);
        }
    }
}

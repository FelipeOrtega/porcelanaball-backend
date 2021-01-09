using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class LancamentoMap : MapBase<Lancamento>
    {
        public override void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasMany(l => l.lancamentoAluno).WithOne(la => la.lancamento);
            builder.HasMany(l => l.lancamentoProduto).WithOne(lp => lp.lancamento);
            builder.HasMany(l => l.lancamentoFormaPagamento).WithOne(lfp => lfp.lancamento);
            base.Configure(builder);
        }
    }
}

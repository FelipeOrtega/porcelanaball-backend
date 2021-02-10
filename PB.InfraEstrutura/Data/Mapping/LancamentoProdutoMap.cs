using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class LancamentoProdutoMap : MapBase<LancamentoProduto>
    {
        public override void Configure(EntityTypeBuilder<LancamentoProduto> builder)
        {
            builder.HasOne(lp => lp.lancamento).WithMany(l => l.lancamentoProduto).HasForeignKey(lt => lt.lancamento_codigo);
            builder.ToTable("LANCAMENTO_PRODUTO");
            base.Configure(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class LancamentoProdutoMap : MapBase<LancamentoProduto>
    {
        public override void Configure(EntityTypeBuilder<LancamentoProduto> builder)
        {
            builder.ToTable("lancamento_produto");
            builder.HasOne(lp => lp.lancamento).WithMany(l => l.lancamentoProduto).HasForeignKey(lt => lt.lancamento_codigo);
            base.Configure(builder);
        }
    }
}

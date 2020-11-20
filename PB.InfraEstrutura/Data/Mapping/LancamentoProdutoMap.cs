using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class LancamentoProdutoMap : MapBase<LancamentoProduto>
    {
        public override void Configure(EntityTypeBuilder<LancamentoProduto> builder)
        {
            base.Configure(builder);
            builder.ToTable("lancamento_produto");
        }
    }
}

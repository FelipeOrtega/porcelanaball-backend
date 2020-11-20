using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class ProdutoCategoriaMap : MapBase<ProdutoCategoria>
    {
        public override void Configure(EntityTypeBuilder<ProdutoCategoria> builder)
        {
            base.Configure(builder);
            builder.ToTable("produto_categoria");
        }
    }
}

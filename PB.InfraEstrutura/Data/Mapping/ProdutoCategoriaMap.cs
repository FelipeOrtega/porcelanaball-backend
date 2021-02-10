using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class ProdutoCategoriaMap : MapBase<ProdutoCategoria>
    {
        public override void Configure(EntityTypeBuilder<ProdutoCategoria> builder)
        {
            builder.ToTable("PRODUTO_CATEGORIA");
            base.Configure(builder);
        }
    }
}

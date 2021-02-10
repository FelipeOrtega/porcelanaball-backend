using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class LancamentoCategoriaMap : MapBase<LancamentoCategoria>
    {
        public override void Configure(EntityTypeBuilder<LancamentoCategoria> builder)
        {
            builder.ToTable("LANCAMENTO_CATEGORIA");
            base.Configure(builder);
        }
    }
}

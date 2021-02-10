using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class LancamentoTipoMap : MapBase<LancamentoTipo>
    {
        public override void Configure(EntityTypeBuilder<LancamentoTipo> builder)
        {
            base.Configure(builder);
            builder.ToTable("LANCAMENTO_TIPO");
        }
    }
}

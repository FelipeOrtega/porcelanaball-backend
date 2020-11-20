using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class LancamentoMap : MapBase<Lancamento>
    {
        public override void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            base.Configure(builder);
        }
    }
}

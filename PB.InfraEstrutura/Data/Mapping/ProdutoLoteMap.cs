using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    class ProdutoLoteMap : MapBase<ProdutoLote>
    {
        public override void Configure(EntityTypeBuilder<ProdutoLote> builder)
        {
            base.Configure(builder);
        }
    }
}

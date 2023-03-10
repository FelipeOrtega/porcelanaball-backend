using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    class ProdutoMap : MapBase<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");
            base.Configure(builder);
        }
    }
}

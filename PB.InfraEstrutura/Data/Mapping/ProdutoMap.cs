﻿using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    class ProdutoMap : MapBase<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasOne(pl => pl.produtoLote).WithMany();
            base.Configure(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class LancamentoFormaPagamentoMap : MapBase<LancamentoFormaPagamento>
    {
        public override void Configure(EntityTypeBuilder<LancamentoFormaPagamento> builder)
        {
            builder.ToTable("lancamento_forma_pagamento");
            builder.HasOne(lfp => lfp.lancamento).WithMany(l => l.lancamentoFormaPagamento).HasForeignKey(lt => lt.lancamento_codigo);
            base.Configure(builder);
        }
    }
}

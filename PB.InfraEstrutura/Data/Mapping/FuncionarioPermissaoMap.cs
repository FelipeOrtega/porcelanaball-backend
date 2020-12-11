using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class FuncionarioPermissaoMap : MapBase<FuncionarioPermissao>
    {
        public override void Configure(EntityTypeBuilder<FuncionarioPermissao> builder)
        {
            builder.HasOne(fp => fp.funcionario).WithMany(f => f.funcionarioPermissao).HasForeignKey(fp => fp.funcionario_codigo);
            base.Configure(builder);
            builder.ToTable("funcionario_permissao");
        }
    }
}

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
            base.Configure(builder);
            builder.ToTable("funcionario_permissao");
        }
    }
}

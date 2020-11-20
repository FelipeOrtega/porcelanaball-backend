using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class FuncionarioPossuiPlanoMap : MapBase<FuncionarioPossuiPlano>
    {
        public override void Configure(EntityTypeBuilder<FuncionarioPossuiPlano> builder)
        {
            base.Configure(builder);
            builder.ToTable("funcionario_possui_plano");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class AlunoPossuiPlanoMap : MapBase<AlunoPossuiPlano>
    {
        public override void Configure(EntityTypeBuilder<AlunoPossuiPlano> builder)
        {
            base.Configure(builder);
            builder.ToTable("aluno_possui_plano");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class AlunoPossuiPlanoMap : MapBase<AlunoPossuiPlano>
    {
        public override void Configure(EntityTypeBuilder<AlunoPossuiPlano> builder)
        {
            builder.HasOne(app => app.aluno).WithMany(a => a.alunoPossuiPlano).HasForeignKey(app => app.aluno_codigo);
            base.Configure(builder);
            builder.ToTable("aluno_possui_plano");
        }
    }
}

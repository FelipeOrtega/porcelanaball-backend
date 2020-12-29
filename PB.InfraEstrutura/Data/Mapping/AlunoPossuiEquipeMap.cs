using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class AlunoPossuiEquipeMap : MapBase<AlunoPossuiEquipe>
    {
        public override void Configure(EntityTypeBuilder<AlunoPossuiEquipe> builder)
        {
            builder.HasOne(app => app.aluno).WithMany(a => a.alunoPossuiEquipe).HasForeignKey(app => app.aluno_codigo);
            base.Configure(builder);
            builder.ToTable("aluno_possui_equipe");
        }
    }
}

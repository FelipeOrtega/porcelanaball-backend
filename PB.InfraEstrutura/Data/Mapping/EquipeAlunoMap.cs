using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class EquipeAlunoMap : MapBase<EquipeAluno>
    {
        public override void Configure(EntityTypeBuilder<EquipeAluno> builder)
        {
            builder.HasOne(app => app.aluno).WithMany(a => a.alunoPossuiEquipe).HasForeignKey(app => app.aluno_codigo);
            base.Configure(builder);
            builder.ToTable("equipe_aluno");
        }
    }
}

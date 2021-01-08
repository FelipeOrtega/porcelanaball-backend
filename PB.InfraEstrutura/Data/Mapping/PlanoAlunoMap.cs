using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class PlanoAlunoMap : MapBase<PlanoAluno>
    {
        public override void Configure(EntityTypeBuilder<PlanoAluno> builder)
        {
            builder.HasOne(app => app.aluno).WithMany(a => a.alunoPossuiPlano).HasForeignKey(app => app.aluno_codigo);
            base.Configure(builder);
            builder.ToTable("plano_aluno");
        }
    }
}

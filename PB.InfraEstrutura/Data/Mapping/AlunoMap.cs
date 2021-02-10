using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class AlunoMap : MapBase<Aluno>
    {
        public override void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasMany(a => a.alunoTreinos).WithOne(at => at.aluno);
            builder.HasMany(a => a.alunoPossuiPlano).WithOne(app => app.aluno);
            builder.HasMany(a => a.alunoPossuiEquipe).WithOne(app => app.aluno);
            builder.ToTable("ALUNO");
            base.Configure(builder);
        }
    }
}

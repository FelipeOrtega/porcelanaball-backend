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
            builder.HasMany(a => a.planoAluno).WithOne(app => app.aluno);
            builder.HasMany(a => a.equipeAluno).WithOne(app => app.aluno).HasForeignKey(c => c.aluno_codigo);
            builder.ToTable("ALUNO");
            base.Configure(builder);
        }
    }
}

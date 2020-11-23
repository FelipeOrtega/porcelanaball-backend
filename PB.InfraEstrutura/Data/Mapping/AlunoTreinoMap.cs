using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class AlunoTreinoMap : MapBase<AlunoTreino>
    {
        public override void Configure(EntityTypeBuilder<AlunoTreino> builder)
        {
            builder.HasOne(at => at.aluno).WithMany(a => a.alunoTreinos).HasForeignKey(at => at.aluno_codigo);
            base.Configure(builder);
            builder.ToTable("aluno_treino");
        }
    }
}

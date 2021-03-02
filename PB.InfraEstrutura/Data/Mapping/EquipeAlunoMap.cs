using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class EquipeAlunoMap : MapBase<EquipeAluno>
    {
        public override void Configure(EntityTypeBuilder<EquipeAluno> builder)
        {
            builder.HasKey(t => new { t.aluno_codigo, t.equipe_codigo});
            builder.HasOne(pt => pt.aluno).WithMany(p => p.equipeAluno).HasForeignKey(pt => pt.aluno_codigo);
            builder.HasOne(pt => pt.equipe).WithMany(p => p.equipeAluno).HasForeignKey(pt => pt.equipe_codigo);
            builder.ToTable("EQUIPE_ALUNO");
            base.Configure(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class LancamentoAlunoMap : MapBase<LancamentoAluno>
    {
        public override void Configure(EntityTypeBuilder<LancamentoAluno> builder)
        {
            builder.ToTable("lancamento_aluno");
            builder.HasOne(la => la.lancamento).WithMany(l => l.lancamentoAluno).HasForeignKey(lt => lt.lancamento_codigo);
            base.Configure(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class EquipeMap : MapBase<Equipe>
    {
        public override void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.HasMany(a => a.equipeAluno).WithOne(app => app.equipe).HasForeignKey(c => c.equipe_codigo);
            builder.ToTable("EQUIPE");
            base.Configure(builder);
        }
    }
}

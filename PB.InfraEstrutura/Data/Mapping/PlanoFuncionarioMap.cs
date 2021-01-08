using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class PlanoFuncionarioMap : MapBase<PlanoFuncionario>
    {
        public override void Configure(EntityTypeBuilder<PlanoFuncionario> builder)
        {
            builder.HasOne(fpp => fpp.funcionario).WithMany(a => a.funcionarioPossuiPlano).HasForeignKey(fpp => fpp.funcionario_codigo);
            base.Configure(builder);
            builder.ToTable("plano_funcionario");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class FuncionarioMap : MapBase<Funcionario>
    {
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasMany(f => f.funcionarioPermissao).WithOne(fp => fp.funcionario);
            builder.HasMany(f => f.modalidadeFuncionario).WithOne(mf => mf.funcionario);
            builder.HasMany(f => f.funcionarioPossuiPlano).WithOne(fpp => fpp.funcionario);
            builder.ToTable("FUNCIONARIO");
            base.Configure(builder);
        }
    }
}
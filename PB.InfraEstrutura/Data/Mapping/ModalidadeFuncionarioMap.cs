using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class ModalidadeFuncionarioMap : MapBase<ModalidadeFuncionario>
    {
        public override void Configure(EntityTypeBuilder<ModalidadeFuncionario> builder)
        {
            builder.HasOne(mf => mf.funcionario).WithMany(f => f.modalidadeFuncionario).HasForeignKey(mf => mf.funcionario_codigo);
            base.Configure(builder);
            builder.ToTable("modalidade_funcionario");
        }
    }
}

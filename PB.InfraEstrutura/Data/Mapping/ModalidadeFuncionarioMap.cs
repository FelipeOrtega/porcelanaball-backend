using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class ModalidadeFuncionarioMap : MapBase<ModalidadeFuncionario>
    {
        public override void Configure(EntityTypeBuilder<ModalidadeFuncionario> builder)
        {
            base.Configure(builder);
            builder.ToTable("modalidade_funcionario");
        }
    }
}

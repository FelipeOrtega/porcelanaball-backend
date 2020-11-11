using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Domain.Core;

namespace PB.InfraEstrutura.Data.Mapping
{
    public class MapBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.codigo);

            builder.Property(c => c.codigo).IsRequired();

        }
    }
}

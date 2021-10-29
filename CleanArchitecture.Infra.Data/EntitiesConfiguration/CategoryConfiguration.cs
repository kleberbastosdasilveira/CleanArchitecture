using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : MapeamentoBase<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t=>t.Name).HasMaxLength(100).IsRequired();

            builder.Ignore(x => x.Notifications);

            base.ConfigurarEntidadeBase(builder);
        }
    }
}

using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : MapeamentoBase<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t=>t.Id);
            builder.Property(t=>t.Name).HasMaxLength(100).IsRequired(); 
            builder.Property(t=>t.Description).HasMaxLength(200).IsRequired();
            builder.Property(t=>t.Price).HasPrecision(10,2);

            builder.HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t=>t.CategoryId);

            builder.Ignore(x=>x.Notifications);

            base.ConfigurarEntidadeBase(builder);
        }
    }
}

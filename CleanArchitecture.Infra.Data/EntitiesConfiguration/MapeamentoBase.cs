using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.Data.EntitiesConfiguration
{
    public abstract class MapeamentoBase<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
        public void ConfigurarEntidadeBase(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .HasColumnName("Data_Cadastro")
                .IsRequired()
                .HasColumnType("datetime2")
                .HasPrecision(0); 
        }
    }
}

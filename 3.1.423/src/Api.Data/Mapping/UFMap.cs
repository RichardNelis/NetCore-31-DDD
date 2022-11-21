using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UFMap : IEntityTypeConfiguration<UFEntity>
    {
        public void Configure(EntityTypeBuilder<UFEntity> builder)
        {
            builder.ToTable("Uf");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Sigla)
                    .IsUnique();
        }
    }
}

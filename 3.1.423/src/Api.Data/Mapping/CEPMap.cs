using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CEPMap : IEntityTypeConfiguration<CEPEntity>
    {
        public void Configure(EntityTypeBuilder<CEPEntity> builder)
        {
            builder.ToTable("Cep");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.CEP);

            builder.HasOne(x => x.Municipio)
                    .WithMany(x => x.CEPs);
        }
    }
}

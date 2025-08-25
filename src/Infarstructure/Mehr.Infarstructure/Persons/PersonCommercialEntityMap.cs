using Mehr.Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Persons;

public class PersonCommercialEntityMap : IEntityTypeConfiguration<PersonCommercial>
{
    public void Configure(EntityTypeBuilder<PersonCommercial> builder)
    {
        builder.ToTable("PersonCommercialTBL");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.Title)
            .HasColumnName("Title")
            .HasMaxLength(200);

        builder.Property(x => x.HexaColor)
            .HasMaxLength(15);
    }
}

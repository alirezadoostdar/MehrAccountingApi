using Mehr.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Persons;

public class PersonTaxKindEntityMap : IEntityTypeConfiguration<PersonTaxKind>
{
    public void Configure(EntityTypeBuilder<PersonTaxKind> builder)
    {
        builder.ToTable("TaxPersonKind");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasColumnName("PersonKindTitle")
            .HasMaxLength(50)
            .IsRequired();
    }
}

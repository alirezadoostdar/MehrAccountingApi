using Mehr.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Persons;

public class PersonSalePriceEntityMap : IEntityTypeConfiguration<PersonSalePrice>
{
    public void Configure(EntityTypeBuilder<PersonSalePrice> builder)
    {
        builder.ToTable("InfoPersonPriceNoTbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Value")
            .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnName("Caption")
            .HasMaxLength(1000)
            .IsRequired();
    }
}

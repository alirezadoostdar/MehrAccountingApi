using Mehr.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Stocks;

public class ProductEntityMap : IEntityTypeConfiguration<Prouduct>
{
    public void Configure(EntityTypeBuilder<Prouduct> builder)
    {
        builder.ToTable("StockTbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("GoodSyscode");

        builder.Property(x => x.Title)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.Code)
            .HasMaxLength(100);

        builder.Property(x => x.Barcode)
            .HasMaxLength(100);

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.FirstUnit)
            .HasColumnName("FstUnit")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.SecondUnit)
            .
    }
}

using Mehr.Domain.Stocks;
using Microsoft.Data.SqlClient;
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
            .HasColumnName("SecUnit")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.UnitRate)
            .IsRequired();

        builder.Property(x => x.OrderPoint)
            .IsRequired();

        builder.Property(x => x.SalePrice1)
            .IsRequired();

        builder.Property(x => x.SalePrice2)
            .IsRequired();

        builder.Property(x => x.SalePrice3)
            .IsRequired();

        builder.Property(x => x.SalePrice4)
            .IsRequired();

        builder.Property(x => x.SalePrice5)
            .IsRequired();

        builder.Property(x => x.VisitorPercent)
            .HasColumnName("VisitorPer");

        builder.Property(x => x.Comment)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.DiscountPercent)
            .HasColumnName("DiscountPer");

        builder.Property(x => x.UserPrice)
            .IsRequired();

        builder.Property(x => x.ProductGroup1)
            .HasColumnName("GroupID1");

        builder.HasOne(x => x.ProductGroup1)
            .WithMany()
            .HasForeignKey(x => x.ProductGroup1);

    }
}

using Mehr.Domain.Stocks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Stocks;

public class ProductEntityMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
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

        builder.Property(x => x.ProductGroup1Id)
            .HasColumnName("GroupID1");

        builder.HasOne(x => x.ProductGroup1)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProductGroup1Id);

        builder.Property(x => x.ProductGroup2Id)
            .HasColumnName("GroupID2");

        builder.HasOne(x => x.ProductGroup2)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProductGroup2Id);

        builder.Property(x => x.HasSerial)
            .HasColumnName("SerialNo")
            .IsRequired();

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.Property(x => x.Term)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.Tax1)
            .HasColumnName("MaliatArzeshAfzoodeh")
            .IsRequired();

        builder.Property(x => x.HasDateExpire)
            .HasColumnName("DateExpite")
            .IsRequired();

        builder.Property(x => x.Tax2)
            .HasColumnName("Avarez")
            .IsRequired();

        builder.Property(x => x.DateExpireAlarm)
            .HasColumnName("Alarm")
            .IsRequired();

        builder.Property(x => x.TechnicalDescription)
            .HasColumnName("TechnicalBox");

        builder.Property(x => x.MaximumQuantity)
            .HasColumnName("MaxQTY");

        builder.Property(x => x.RightToLeft)
            .HasColumnName("rtlTOlft");

        builder.Property(x => x.UnderSalePrice)
            .IsRequired();

        builder.Property(x => x.IsCardDiscount)
            .IsRequired();

        builder.Property(x => x.NotReturn)
            .IsRequired();

        builder.Property(x => x.Field1)
            .HasMaxLength(1000);

        builder.Property(x => x.Field2)
            .HasMaxLength(1000);

        builder.Property(x => x.Field3)
            .HasMaxLength(1000);

        builder.Property(x => x.LastPurchasePrice)
            .HasColumnName("BuyLastFee")
            .IsRequired();

        builder.Property(x => x.ImageName)
            .HasMaxLength(200);

        builder.Property(x => x.IsUpdate)
            .IsRequired();

        builder.Property(x => x.ProductGroup3Id)
            .HasColumnName("GroupID3");

        builder.HasOne(x => x.productGroup3)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProductGroup3Id);

        builder.Property(x => x.ProductCategoryId)
            .HasColumnName("CategoryID");

        builder.HasOne(x => x.ProductCategory)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProductCategoryId);

        builder.Property(x => x.SendToServer)
            .IsRequired();

        builder.Property(x => x.LastPurchasePriceNoCost)
            .HasColumnName("LastFeeNoCost")
            .IsRequired();

        builder.Property(x => x.Field4)
            .HasMaxLength(200);

        builder.Property(x => x.Field5)
            .HasMaxLength(200);

        builder.Property(x => x.GovermentTaxId)
            .HasColumnName("IdTaxGov");

        builder.Property(x => x.TaxUnitId)
            .HasColumnName("Fk_TaxUnitId");

        builder.Property(x => x.CheckList)
            .IsRequired();
    }
}

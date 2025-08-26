using Mehr.Domain.Entities.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Stocks;

public class ProductGroup2EntityMap : IEntityTypeConfiguration<ProductGroup2>
{
    public void Configure(EntityTypeBuilder<ProductGroup2> builder)
    {
        builder.ToTable("stockGroup2Tbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("GroupId");

        builder.Property(x => x.Title)
            .HasColumnName("GroupName")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.VisitPercent)
            .HasColumnName("VisitPercent");
    }
}
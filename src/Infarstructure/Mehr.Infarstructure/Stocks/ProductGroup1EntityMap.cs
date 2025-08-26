using Mehr.Domain.Entities.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Stocks;

public class ProductGroup1EntityMap : IEntityTypeConfiguration<ProductGroup1>
{
    public void Configure(EntityTypeBuilder<ProductGroup1> builder)
    {
        builder.ToTable("stockGroup1Tbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("GroupId");

        builder.Property(x => x.Title)
            .HasColumnName("GroupName")
            .HasMaxLength(100)
            .IsRequired();
    }
}

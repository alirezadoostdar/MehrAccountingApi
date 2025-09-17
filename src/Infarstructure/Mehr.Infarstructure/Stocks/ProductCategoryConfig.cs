using Mehr.Domain.Entities.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Stocks;

public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("GoodsCategoryTBL");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.Title)
            .HasColumnName("Title")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.ParentId)
            .HasColumnName("PID")
            .IsRequired();

        builder.Property(x => x.Image)
            .HasColumnName("CatImage");

        builder.Property(x => x.ImageUrl)
            .HasColumnName("CatImageURL")
            .HasMaxLength(200);
    }
}

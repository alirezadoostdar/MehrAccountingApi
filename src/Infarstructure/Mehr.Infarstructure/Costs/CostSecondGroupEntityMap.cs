using Mehr.Domain.Entities.Costs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Costs;

public class CostSecondGroupEntityMap : IEntityTypeConfiguration<CostSecondGroup>
{
    public void Configure(EntityTypeBuilder<CostSecondGroup> builder)
    {
        builder.ToTable("CostGroup2Tbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .HasColumnName("GroupId")
           .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnName("GroupName")
            .HasMaxLength(100)
            .IsRequired();
    }
}

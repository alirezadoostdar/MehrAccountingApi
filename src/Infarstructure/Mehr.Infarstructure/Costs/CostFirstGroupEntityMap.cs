using Mehr.Domain.Entities.Costs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Mehr.Infarstructure.Costs;

public class CostFirstGroupEntityMap : IEntityTypeConfiguration<CostFirstGroup>
{
    public void Configure(EntityTypeBuilder<CostFirstGroup> builder)
    {
        builder.ToTable("CostGroup1Tbl");

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

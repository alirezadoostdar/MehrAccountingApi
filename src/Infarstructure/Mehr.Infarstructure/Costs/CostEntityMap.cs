using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Costs;
using Mehr.Domain.Entities.Docs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Costs;

public class CostEntityMap : IEntityTypeConfiguration<Cost>
{
    public void Configure(EntityTypeBuilder<Cost> builder)
    {
        builder.ToTable("CostTbl");

        builder.Property(x => x.Id)
            .HasColumnName("Fk_AccountSyscode")
            .ValueGeneratedNever();

        builder.Property(x => x.FirstGroupId)
           .HasColumnName("GroupID1");

        builder.Property(x => x.SecondGroupId)
            .HasColumnName("GroupID2");

        builder.Property(x => x.Comment)
            .HasMaxLength(1000)
            .IsRequired();
    }
}
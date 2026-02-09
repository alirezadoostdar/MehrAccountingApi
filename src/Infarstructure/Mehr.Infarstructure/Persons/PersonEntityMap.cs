using Mehr.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Persons;

public class PersonEntityMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("PersonTbl", tb =>
        {
            tb.Property(e => e.Id).HasColumnName("Fk_AccountSysCode");
        });

        builder.Property(x => x.FirstGroupId)
           .HasColumnName("GroupID1");

        builder.Property(x => x.SecondGroupId)
            .HasColumnName("GroupID2");

        builder.Property(x => x.VisitorPercent)
            .HasColumnName("VisitorPer")
            .IsRequired();

        builder.Property(x => x.Comment)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.Introducer)
            .IsRequired();

        builder.Property(x => x.SellPriceTpye)

    }
}

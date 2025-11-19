using Mehr.Domain.Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Banks;

public class BankDocItemEntityMap : IEntityTypeConfiguration<BankDocItem>
{
    public void Configure(EntityTypeBuilder<BankDocItem> builder)
    {
        builder.ToTable("BankDetailTbl", tb =>
        {
            tb.Property(e => e.Id).HasColumnName("Fk_DocDetailsyscode");
        });

        builder.Property(x => x.TransactionNumber)
            .HasColumnName("Number")
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.IsPos)
            .IsRequired();
    }
}

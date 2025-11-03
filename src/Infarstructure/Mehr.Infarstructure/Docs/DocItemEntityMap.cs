using Mehr.Domain.Docs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Docs;

public class DocItemEntityMap : IEntityTypeConfiguration<DocItem>
{
    public void Configure(EntityTypeBuilder<DocItem> builder)
    {
        builder.ToTable("DocDetailTbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Syscode");

        builder.Property(x => x.DocId)
            .HasColumnName("Fk_docSysCode");

        builder.Property(x => x.DetailedAccountId)
            .HasColumnName("Fk_AccountSyscode");

        builder.Property(x => x.AmountIn)
            .IsRequired()
            .HasColumnName("AmmountIN");

        builder.Property(x => x.AmountOut)
            .IsRequired()
            .HasColumnName("AmmountOUT");

        builder.Property(x => x.RowNumber)
            .IsRequired()
            .HasColumnName("UserRowNo");

        builder.Property(x => x.ArchiveName)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.SecondDetailedAccountId)
            .IsRequired()
            .HasColumnName("SndFk_AccountSyscode");

        builder.Property(x => x.Comment)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(x => x.CurrencyAmount1)
            .IsRequired()
            .HasColumnName("Cur1Amount");

        builder.Property(x => x.CurrencyAmount2)
            .IsRequired()
            .HasColumnName("Cur2Amount");

        builder.Property(x => x.CurrencyAmount3)
            .IsRequired()
            .HasColumnName("Cur3Amount");

        builder.Property(x => x.VisitorId)
            .IsRequired()
            .HasColumnName("FK_VisitorSysCode");

        builder.Property(x => x.LeadAccountId)
            .IsRequired()
            .HasColumnName("Fk_AccountId");

        builder.Property(x => x.IsMoeinRow)
            .IsRequired();
       
    }
}

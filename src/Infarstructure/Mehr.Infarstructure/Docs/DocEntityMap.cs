using Mehr.Domain.Entities.Docs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Docs;

public class DocEntityMap : IEntityTypeConfiguration<Doc>
{
    public void Configure(EntityTypeBuilder<Doc> builder)
    {
        builder.ToTable("DocTbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("SysCode");

        builder.Property(x => x.ShamsiDate)
            .HasColumnName("DocDate")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.CreateAt)
            .HasColumnName("SysDate")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnName("UserIDNO");

        builder.Property(x => x.Comment)
            .HasMaxLength(1000);

        builder.Property(x => x.ArchiveName)
            .HasMaxLength(1000);

        builder.Property(x => x.CreateShamsiAt)
            .HasColumnName("SysShamsiDate")
            .HasMaxLength(10);

        builder.Property(x => x.StringCode)
            .HasColumnName("StrCode")
            .HasMaxLength(13);

        builder.Property(x => x.NumericCode)
            .HasColumnName("NumCode");

        builder.Property(x => x.CurrencyBaseRate1)
            .HasColumnName("CurBaseRate1")
            .IsRequired();

        builder.Property(x => x.CurrencyBaseRate2)
            .HasColumnName("CurBaseRate2")
            .IsRequired();

        builder.Property(x => x.CurrencyBaseRate3)
            .HasColumnName("CurBaseRate3")
            .IsRequired();

        builder.Property(x => x.CurrencyRate1Part2)
            .HasColumnName("CurRate1Part2")
            .IsRequired();


        builder.Property(x => x.CurrencyRate2Part2)
            .HasColumnName("CurRate2Part2")
            .IsRequired();


        builder.Property(x => x.CurrencyRate3Part2)
            .HasColumnName("CurRate3Part2")
            .IsRequired();

        builder.Property(x => x.Date)
            .HasColumnName("DocMiladiDate");

        builder.Property(x => x.ProjectId)
            .HasColumnName("Fk_ProjectID");

        builder.Property(x => x.Type)
            .HasColumnName("Fk_TypeID")
            .IsRequired();

        builder.Property(x => x.IsTemp)
            .IsRequired();

        builder.Property(x => x.OpeningLeadAccountCode)
            .HasColumnName("OpeningMoeinCode");

        builder.Property(x => x.FinancialYearId)
            .HasColumnName("Fk_YearId")
            .IsRequired();

        builder.Property(x => x.Code)
            .HasColumnName("code");

        builder.Property(x => x.ModifiedAt)
            .HasColumnName("ModifiedDate");

    }
}

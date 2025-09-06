using Mehr.Domain.Entities.FinancialYears;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.FinancialYears;

public class FinancialYearEntityMap : IEntityTypeConfiguration<FinancialYear>
{
    public void Configure(EntityTypeBuilder<FinancialYear> builder)
    {
        builder.ToTable("FinancialYear");

        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(_ => _.StartDateShamsi)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(_ => _.StartDateMiladi)
            .IsRequired();

        builder.Property(_ => _.EndDateShamsi)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(_ => _.EndDateMiladi)
            .IsRequired();

        builder.Property(_ => _.RegisterDate)
            .IsRequired();

        builder.Property(_ => _.Active)
            .IsRequired();
    }
}

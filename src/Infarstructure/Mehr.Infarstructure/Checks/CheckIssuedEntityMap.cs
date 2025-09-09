using Mehr.Domain.Entities.Checks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Checks;

public class CheckIssuedEntityMap : IEntityTypeConfiguration<Check_Issued>
{
    public void Configure(EntityTypeBuilder<Check_Issued> builder)
    {
        builder.ToTable("CheckOUTTBL");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("FK_DocSysCode")
            .IsRequired();

        builder.Property(x => x.SerialNumber)
            .HasColumnName("SerialNo")
            .IsRequired();

        builder.Property(x => x.Comment)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.BankId)
            .HasColumnName("FK_BankAccount")
            .IsRequired();

        builder.Property(x => x.Date)
            .HasColumnName("CheckMiladiDate")
            .IsRequired();

        builder.Property(x => x.ShamsiDate)
            .HasColumnName("CheckDate")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.PersonId)
            .HasColumnName("Belongto");
    }
}

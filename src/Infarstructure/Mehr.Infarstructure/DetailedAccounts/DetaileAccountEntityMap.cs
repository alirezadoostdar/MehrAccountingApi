using Mehr.Domain.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.DetailedAccounts;

public class DetaileAccountEntityMap : IEntityTypeConfiguration<DetailedAccount>
{
    public void Configure(EntityTypeBuilder<DetailedAccount> builder)
    {
        builder.ToTable("CodeMNGDWNTbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("AccountSysCode");

        builder.Property(x => x.Title)
            .IsRequired();

        builder.Property(x => x.CategoryId)
            .HasColumnName("FK_AccountSysCode0")
            .IsRequired();

        builder.Property(x => x.CreditLimit)
            .HasColumnName("CreditLimit")
            .IsRequired();

        builder.Property(x => x.SecureLevelId)
            .HasColumnName("SecurLevel")
            .IsRequired();

        builder.Property(x => x.IsDebtor)
            .HasColumnName("BedehkarOnly");

        builder.Property(x => x.IsUpdate)
            .IsRequired();

        builder.HasOne(x => x.SecureLevel)
            .WithMany()
            .HasForeignKey(x => x.SecureLevelId);

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId);
    }
}

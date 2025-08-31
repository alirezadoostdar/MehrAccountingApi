using Mehr.Domain.Entities.Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Banks;
public class BankEntityMap : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.ToTable("BanksTbl");

        builder.Property(x => x.AccountNumber)
            .HasColumnName("AccountNo")
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(x => x.Manager)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.ContactId)
            .HasColumnName("ContactID")
            .IsRequired();

        builder.Property(x => x.Comment)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.CardNumber)
            .HasColumnName("CardNo")
            .HasMaxLength(20);

        builder.Property(x => x.Iban)
            .HasMaxLength(50);

        builder.Property(x => x.PaySwitchNumber)
            .HasColumnName("PaySwitchNo")
            .HasMaxLength(20);

        builder.Property(x => x.ShoppingNumber)
            .HasColumnName("ShoppingNo")
            .HasMaxLength(30);

        builder.Property(x => x.TerminalNumber)
            .HasColumnName("TerminalNo")
            .HasMaxLength(20);

    }
}

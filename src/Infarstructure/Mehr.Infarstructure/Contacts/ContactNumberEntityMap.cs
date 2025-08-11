using Mehr.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Contacts;

public class ContactNumberEntityMap : IEntityTypeConfiguration<ContactNumber>
{
    public void Configure(EntityTypeBuilder<ContactNumber> builder)
    {
        builder.ToTable("TelNumbers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("SysCode");

        builder.Property(x => x.ContactInfoId)
            .HasColumnName("TelBookID")
            .IsRequired();

        builder.Property(x => x.Number)
            .HasColumnName("TelNo")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.ContactTypeId)
            .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnName("Title")
            .HasMaxLength(50);

        builder.HasOne(x => x.ContactType)
            .WithMany()
            .HasForeignKey(x => x.ContactInfoId)
            .IsRequired();

        builder.HasOne(x => x.ContactInfo)
            .WithMany(x => x.Numbers)
            .HasForeignKey(x => x.ContactInfoId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

    }
}

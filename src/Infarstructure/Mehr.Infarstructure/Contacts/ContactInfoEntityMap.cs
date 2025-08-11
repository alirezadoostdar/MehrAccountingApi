using Mehr.Domain.Entities.Contacts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Contacts;

public class ContactInfoEntityMap : IEntityTypeConfiguration<ContactInfo>
{
    public void Configure(EntityTypeBuilder<ContactInfo> builder)
    {
        builder.ToTable("TelBook");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Address)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Comment)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.SecurityType)
            .HasColumnName("OwnerUserID")
            .IsRequired();

        builder.Property(x => x.CityId)
            .HasColumnName("FK_IDCity");

        builder.Property(x => x.StateId)
            .HasColumnName("FK_IDOstan");

        builder.Property(x => x.ZoneId)
            .HasColumnName("FK_Zone");

        builder.Property(x => x.ShopName)
            .HasColumnName("Company")
            .HasMaxLength(50);

        builder.Property(x => x.TelegramId)
            .HasColumnName("TelegramID")
            .HasMaxLength(200);

        builder.Property(x => x.TelegramMobileNumber)
            .HasColumnName("TelegramMobileNo")
            .HasMaxLength(50);

    }
}

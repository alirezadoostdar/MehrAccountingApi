using Mehr.Domain.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Contacts;

public class ContactImageEntityMap : IEntityTypeConfiguration<ContactImage>
{
    public void Configure(EntityTypeBuilder<ContactImage> builder)
    {
        builder.ToTable("ContactImagesTBL");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.Name)
            .HasColumnName("ImageName")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Image)
            .HasColumnName("Images")
            .HasColumnType("image")
            .IsRequired();

        builder.Property(x => x.ContactInfoId)
            .HasColumnName("FK_TelBookID")
            .IsRequired();
    }
}

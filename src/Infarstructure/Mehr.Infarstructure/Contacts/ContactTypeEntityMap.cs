using Mehr.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Contacts;

public class ContactTypeEntityMap : IEntityTypeConfiguration<ContactType>
{
    public void Configure(EntityTypeBuilder<ContactType> builder)
    {
        builder.ToTable("TelTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasColumnName("TelTypes")
            .HasMaxLength(50)
            .IsRequired();
    }
}

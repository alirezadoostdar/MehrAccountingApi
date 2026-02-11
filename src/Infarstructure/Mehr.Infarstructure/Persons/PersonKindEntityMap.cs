using Mehr.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Persons;

public class PersonKindEntityMap : IEntityTypeConfiguration<PersonKind>
{
    public void Configure(EntityTypeBuilder<PersonKind> builder)
    {
        builder.ToTable("PersonKind");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.Title)
            .HasColumnName("Kind")
            .HasMaxLength(200)
            .IsRequired();
    }
}

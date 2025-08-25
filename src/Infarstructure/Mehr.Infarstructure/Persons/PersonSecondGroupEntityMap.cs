using Mehr.Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Persons;

public class PersonSecondGroupEntityMap : IEntityTypeConfiguration<PersonSecondGroup>
{
    public void Configure(EntityTypeBuilder<PersonSecondGroup> builder)
    {
        builder.ToTable("PersonGroup2Tbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("GroupId");

        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .HasColumnName("GroupName")
            .IsRequired();
    }
}
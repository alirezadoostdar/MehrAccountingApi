using Mehr.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Contacts;

public class CityEntityMap : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("CityTbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Code")
            .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnName("Name")
            .IsRequired();

        builder.Property(x => x.StateId)
            .HasColumnName("FK_Ostan")
            .IsRequired();

        builder.HasOne(x => x.State)
            .WithMany(x => x.Cities)
            .HasForeignKey(x => x.StateId);
    }
}

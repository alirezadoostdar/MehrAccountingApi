using Mehr.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Contacts;

public class StateEntityMap : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("OstanTbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("OstanCode")
            .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnName("Name")
            .HasMaxLength(200)
            .IsRequired();
    }
}

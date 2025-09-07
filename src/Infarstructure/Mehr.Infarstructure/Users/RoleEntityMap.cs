using Mehr.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Users;

public class RoleEntityMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Groups");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("GID");

        builder.Property(x => x.Title)
            .HasColumnName("Gname")
            .HasMaxLength(1000)
            .IsRequired();
    }
}

using Mehr.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Users;
public class UserEntityMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("UID");

        builder.Property(x => x.RoleId)
            .HasColumnName("GID")
            .IsRequired();

        builder.Property(x => x.UserName)
            .HasColumnName("UName")
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.SecureLevel)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnName("PassWord")
            .HasMaxLength(4000)
            .IsRequired();

        builder.Property(x => x.IsDisable)
            .HasColumnName("Disable");

        builder.Property(x => x.ModifiedAt)
            .HasColumnName("ModifiedDate")
            .IsRequired();
    }
}

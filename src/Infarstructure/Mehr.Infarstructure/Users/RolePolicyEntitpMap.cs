using Mehr.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Users;

public class RolePolicyEntitpMap : IEntityTypeConfiguration<RolePolicy_QueryModel>
{
    public void Configure(EntityTypeBuilder<RolePolicy_QueryModel> builder)
    {
        builder.HasNoKey()
            .ToView(null);

        builder.Property(x => x.Id)
            .HasColumnName("PID");

        builder.Property(x => x.Level)
            .HasColumnName("PLevel");

        builder.Property(x => x.Title)
            .HasColumnName("PName");

        builder.Property(x => x.Value)
            .HasColumnName("PValue");
    }
}

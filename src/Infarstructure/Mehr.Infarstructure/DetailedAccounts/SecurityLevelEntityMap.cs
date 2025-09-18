using Mehr.Domain.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.DetailedAccounts;

public class SecurityLevelEntityMap : IEntityTypeConfiguration<SecurityLevel>
{
    public void Configure(EntityTypeBuilder<SecurityLevel> builder)
    {
        builder.ToTable("InfoSecurityLevelTbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Value");

        builder.Property(x => x.Title)
            .HasColumnName("Caption")
            .HasMaxLength(1000);
    }
}

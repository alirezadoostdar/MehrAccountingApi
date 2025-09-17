using Mehr.Domain.Entities.Accounts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.DetailedAccounts;

public class DetailedCategoryAccountConfig : IEntityTypeConfiguration<DetailedCategoryAccount>
{
    public void Configure(EntityTypeBuilder<DetailedCategoryAccount> builder)
    {
        builder.ToTable("CodeMNGUPTbl");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("CodeMNGUPTbl")
            .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnName("Title")
            .IsRequired();

        builder.Property(x => x.Type)
            .HasColumnName("Kind")
            .IsRequired();

        builder.Property(x => x.Private)
            .HasColumnName("Private");

        builder.Property(x => x.IsDetailedCategory)
            .HasColumnName("IsTafsilGroup")
            .IsRequired();
    }
}

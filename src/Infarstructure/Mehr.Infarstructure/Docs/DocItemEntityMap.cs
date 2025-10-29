using Mehr.Domain.Entities.Docs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mehr.Infarstructure.Docs;

public class DocItemEntityMap : IEntityTypeConfiguration<DocItem>
{
    public void Configure(EntityTypeBuilder<DocItem> builder)
    {
        builder.ToTable("DocDetailTbl");
    }
}

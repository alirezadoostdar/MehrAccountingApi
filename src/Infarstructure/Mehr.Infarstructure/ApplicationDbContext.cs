using Mehr.Domain.Entities.Stocks;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<ProductCategory> ProductCategories { get; set; }
}

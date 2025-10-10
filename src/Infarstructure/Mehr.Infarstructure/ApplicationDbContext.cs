using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Contacts;
using Mehr.Domain.Entities.Costs;
using Mehr.Domain.Entities.Stocks;
using Mehr.Infarstructure.Costs;
using Mehr.Infarstructure.DetailedAccounts;
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
        modelBuilder.ApplyConfiguration(new DetaileAccountEntityMap());
        modelBuilder.ApplyConfiguration(new DetailedCategoryAccountConfig());
        modelBuilder.ApplyConfiguration(new CostEntityMap());
        modelBuilder.ApplyConfiguration(new CostFirstGroupEntityMap());
        modelBuilder.ApplyConfiguration(new CostSecondGroupEntityMap());
        modelBuilder.ApplyConfiguration(new SecurityLevelEntityMap());
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<DetailedAccount> DetailedAccounts{ get; set; }
    public DbSet<DetailedCategoryAccount> DetailedCategoryAccounts { get; set; }
    public DbSet<Cost> Costs { get; set; }
    public DbSet<CostFirstGroup> CostFirstGroups { get; set; }
    public DbSet<CostSecondGroup> CostSecondGroups { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Zone> Zones { get; set; }
}

using Mehr.Domain.Contacts;
using Mehr.Domain.Docs;
using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Costs;
using Mehr.Domain.Entities.Persons;
using Mehr.Domain.FinancialYears;
using Mehr.Domain.Persons;
using Mehr.Domain.Stocks;
using Mehr.Domain.Users;
using Mehr.Domain.Zones;
using Mehr.Infarstructure.Costs;
using Mehr.Infarstructure.DetailedAccounts;
using Mehr.Infarstructure.Docs;
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
        //modelBuilder.ApplyConfiguration(new DetaileAccountEntityMap());
        //modelBuilder.ApplyConfiguration(new DetailedCategoryAccountConfig());
        //modelBuilder.ApplyConfiguration(new CostEntityMap());
        //modelBuilder.ApplyConfiguration(new CostFirstGroupEntityMap());
        //modelBuilder.ApplyConfiguration(new CostSecondGroupEntityMap());
        //modelBuilder.ApplyConfiguration(new SecurityLevelEntityMap());
        //modelBuilder.ApplyConfiguration(new DocEntityMap());
        //modelBuilder.ApplyConfiguration(new DocItemEntityMap());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<DetailedAccount> DetailedAccounts{ get; set; }
    public DbSet<DetailedCategoryAccount> DetailedCategoryAccounts { get; set; }
    public DbSet<Cost> Costs { get; set; }
    public DbSet<CostFirstGroup> CostFirstGroups { get; set; }
    public DbSet<CostSecondGroup> CostSecondGroups { get; set; }

    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonCommercial> PersonCommercials{ get; set; }
    public DbSet<PersonFirstGroup> PersonFirstGroups { get; set; }
    public DbSet<PersonSecondGroup> PersonSecondGroups { get; set; }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Zone> Zones { get; set; }
    public DbSet<Doc> Docs{ get; set; }
    public DbSet<DocItem> DocItems{ get; set; }
    public DbSet<FinancialYear> FinancialYears{ get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePolicy_QueryModel> RolePloicies_QueryModel { get; set; }

    public DbSet<ContactInfo> Contacts{ get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<ContactType> ContactTypes { get; set; }
    public DbSet<ContactNumber> ContactNumbers { get; set; }
    public DbSet<ContactImage> ContactImages { get; set; }
}

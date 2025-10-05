using Mehr.Domain.Entities.Banks;
using Mehr.Domain.Entities.Costs;
using Mehr.Domain.Interfaces.Costs;

namespace Mehr.Infarstructure.Costs;

public class EfCostRepository : ICostRepository
{
    private readonly ApplicationDbContext _context;

    public EfCostRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Cost cost, CancellationToken cancellation)
    {
       await _context.Costs.AddAsync(cost);
    }

    public async Task AddFirstGroupAsync(CostFirstGroup costFirstGroup, CancellationToken cancellation)
    {
        await _context.CostFirstGroups.AddAsync(costFirstGroup, cancellation);
    }

    public async Task AddSecondGroupAsync(CostSecondGroup costSecondGroup, CancellationToken cancellation)
    {
        await _context.CostSecondGroups.AddAsync(costSecondGroup);
    }
}

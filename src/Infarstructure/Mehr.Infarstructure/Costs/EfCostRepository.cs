using Mehr.Domain.Entities.Costs;
using Mehr.Domain.Interfaces.Costs;
using Microsoft.EntityFrameworkCore;

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

    public void DeleteFirstGroup(CostFirstGroup costFirstGroup)
    {
        _context.CostFirstGroups.Remove(costFirstGroup);
    }

    public async Task<List<CostFirstGroup>> GetAllFirstGroupAsync(CancellationToken cancellationToken)
    {
        return await _context.CostFirstGroups.ToListAsync(cancellationToken);
    }

    public async Task<List<CostSecondGroup>> GetAllSecondGroupAsync(CancellationToken cancellationToken)
    {
        return await _context.CostSecondGroups.ToListAsync(cancellationToken);
    }

    public async Task<CostFirstGroup?> GetFirstGroupByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.CostFirstGroups.FindAsync(id, cancellationToken);
    }
}

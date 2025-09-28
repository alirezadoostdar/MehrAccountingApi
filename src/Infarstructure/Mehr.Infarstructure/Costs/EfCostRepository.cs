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
}

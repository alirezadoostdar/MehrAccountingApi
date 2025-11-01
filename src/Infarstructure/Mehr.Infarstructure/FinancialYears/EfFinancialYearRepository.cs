using Mehr.Domain.FinancialYears;
using Mehr.Domain.FinancialYears.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.FinancialYears;

public class EfFinancialYearRepository : IFinancialYearRepositrory
{
    private readonly ApplicationDbContext _context;

    public EfFinancialYearRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<FinancialYear>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.FinancialYears.ToListAsync(cancellationToken);
    }
}

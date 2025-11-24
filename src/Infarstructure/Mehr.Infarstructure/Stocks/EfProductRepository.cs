using Mehr.Domain.Stocks;
using Mehr.Domain.Stocks.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Stocks;

public class EfProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public EfProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }
}

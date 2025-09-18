using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Interfaces.DetailedAccounts;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.DetailedAccounts;

public class EfDetailedAccountRepository : IDetailedAccountRepository
{
    private readonly ApplicationDbContext _context;


    public EfDetailedAccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(DetailedAccount account, CancellationToken cancellationToken)
    {
       await _context.DetailedAccounts.AddAsync(account, cancellationToken);
    }

    public Task DeleteAsync(DetailedAccount account, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<DetailedAccount>> GetAllAsync(CancellationToken cancellationToken)
    {
        var list =  await _context.DetailedAccounts.ToListAsync(cancellationToken);
        return list;
    }

    public List<DetailedAccount> GetAllByCategoryAsync(DetailedCategoryType category, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public DetailedAccount GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(DetailedAccount account, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

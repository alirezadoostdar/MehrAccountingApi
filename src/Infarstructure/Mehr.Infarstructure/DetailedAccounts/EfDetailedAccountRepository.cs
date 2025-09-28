using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Accounts.Dtos;
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

    public void Delete(DetailedAccount account)
    {
        _context.DetailedAccounts.Remove(account);
    }

    public async Task<DetailedAccount?> FindAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.DetailedAccounts.FindAsync(id, cancellationToken);
    }

    public async Task<List<GetDetailedAccountDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var list = await _context.DetailedAccounts
        .Select(x => new GetDetailedAccountDto
        {
            Id = x.Id,
            Title = x.Title,
            CreditLimit = x.CreditLimit,
            IsDebtor = x.IsDebtor,
            Category = x.Category.Title,
            SecureLevel = x.SecureLevel.Title
        }).ToListAsync(cancellationToken);
        return list;
    }

    public List<DetailedAccount> GetAllByCategoryAsync(DetailedCategoryType category, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<GetDetailedAccountDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {

        var account = await _context.DetailedAccounts
            .Where(x => x.Id == id)
            .Select(x => new GetDetailedAccountDto
            {
                Id = x.Id,
                Title = x.Title,
                Category = x.Category.Title,
                SecureLevel = x.SecureLevel.Title,
                CreditLimit = x.CreditLimit,
                IsDebtor = x.IsDebtor
            }).FirstOrDefaultAsync(cancellationToken);

        return account;
    }

    public Task UpdateAsync(DetailedAccount account, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

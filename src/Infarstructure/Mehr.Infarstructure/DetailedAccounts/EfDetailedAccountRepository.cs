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

    public Task DeleteAsync(DetailedAccount account, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<DetailedAccount> FindAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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
        GetDetailedAccountDto? dto = new GetDetailedAccountDto();
        var account = await _context.DetailedAccounts.FindAsync(id, cancellationToken);
        if (account is null)
        {
            dto = null;
            return dto;
        }

        dto.Id = account.Id;
        dto.Title = account.Title;
        dto.Category = account.Category.Title;
        dto.CreditLimit = account.CreditLimit;
        dto.IsDebtor = account.IsDebtor;
        dto.SecureLevel = account.SecureLevel.Title;
        
        return dto;
    }

    public Task UpdateAsync(DetailedAccount account, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

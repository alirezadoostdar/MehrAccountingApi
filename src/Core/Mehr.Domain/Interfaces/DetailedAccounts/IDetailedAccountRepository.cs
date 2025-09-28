using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Accounts.Dtos;

namespace Mehr.Domain.Interfaces.DetailedAccounts;

public interface IDetailedAccountRepository
{
    Task<GetDetailedAccountDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<GetDetailedAccountDto>> GetAllAsync(CancellationToken cancellationToken);
    List<DetailedAccount> GetAllByCategoryAsync(DetailedCategoryType category, CancellationToken cancellationToken);
    Task AddAsync(DetailedAccount account, CancellationToken cancellationToken);
    Task UpdateAsync(DetailedAccount account, CancellationToken cancellationToken);
    Task DeleteAsync(DetailedAccount account, CancellationToken cancellationToken);
    Task<DetailedAccount?> FindAsync(int id, CancellationToken cancellationToken);
}

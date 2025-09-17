using Mehr.Domain.Entities.Accounts;

namespace Mehr.Domain.Interfaces.DetailedAccounts;

public interface IDetailedAccountRepository
{
    DetailedAccount GetByIdAsync(int id, CancellationToken cancellationToken);
    List<DetailedAccount> GetAllAsync(CancellationToken cancellationToken);
    List<DetailedAccount> GetAllByCategoryAsync(DetailedCategoryType category, CancellationToken cancellationToken);
    Task AddAsync(DetailedAccount account, CancellationToken cancellationToken);
    Task UpdateAsync(DetailedAccount account, CancellationToken cancellationToken);
    Task DeleteAsync(DetailedAccount account, CancellationToken cancellationToken);
}

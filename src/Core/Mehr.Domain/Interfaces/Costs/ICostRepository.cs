using Mehr.Domain.Entities.Costs;

namespace Mehr.Domain.Interfaces.Costs;

public interface ICostRepository
{
    Task AddAsync(Cost cost, CancellationToken cancellation);

    Task AddFirstGroupAsync(CostFirstGroup costFirstGroup, CancellationToken cancellation);
    Task<List<CostFirstGroup>> GetAllFirstGroupAsync(CancellationToken cancellationToken);
    Task<CostFirstGroup?> GetFirstGroupByIdAsync(int id, CancellationToken cancellationToken);
    void DeleteFirstGroup(CostFirstGroup costFirstGroup);

    Task AddSecondGroupAsync(CostSecondGroup costSecondGroup, CancellationToken cancellation);
    Task<List<CostSecondGroup>> GetAllSecondGroupAsync(CancellationToken cancellationToken);
}

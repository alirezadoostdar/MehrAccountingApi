using Mehr.Domain.Entities.Costs;

namespace Mehr.Domain.Interfaces.Costs;

public interface ICostRepository
{
    Task AddAsync(Cost cost, CancellationToken cancellation);
}

using Mehr.Application.Costs.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.Costs.Contracts;

public interface ICostService
{
    Task<Result<int>> AddAsync(AddCostDto cost, CancellationToken cancellation);
    Task<Result<int>> AddFirstGroupAsync(AddCostFristGroupDto dto, CancellationToken cancellationToken);
    Task<Result<int>> AddSecondGroupAsync(AddCostSecondGroupDto dto, CancellationToken cancellationToken);
}

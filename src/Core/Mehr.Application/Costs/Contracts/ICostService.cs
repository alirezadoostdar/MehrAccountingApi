using Mehr.Application.Costs.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.Costs.Contracts;

public interface ICostService
{
    Task<Result<int>> AddAsync(AddCostDto cost, CancellationToken cancellation);
}

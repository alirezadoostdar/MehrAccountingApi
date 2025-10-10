using Mehr.Application.Costs.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.Costs.Contracts;

public interface ICostService
{
    Task<Result<int>> AddAsync(AddCostDto cost, CancellationToken cancellation);

    Task<Result<int>> AddFirstGroupAsync(AddCostFristGroupDto dto, CancellationToken cancellationToken);
    Task<Result<List<GetCostFristGroupDto>>> GetAllFirstGroupAsync(CancellationToken cancellationToken);
    Task<Result<bool>> DeleteFirstGroupAsync(int id, CancellationToken cancellationToken);
    Task<Result<bool>> UpdateCostFirstGroupAsync(int id, UpdateCostFirstGroupDto dto,
    CancellationToken cancellationToken);


    Task<Result<int>> AddSecondGroupAsync(AddCostSecondGroupDto dto, CancellationToken cancellationToken);
    Task<Result<List<GetCostSecondGroupDto>>> GetAllSecondGroupAsync(CancellationToken cancellationToken);
    Task<Result<bool>> DeleteSecondGroupAsync(int id, CancellationToken cancellationToken);
    Task<Result<bool>> UpdateCostSecondGroupAsync(int id, UpdateCostSecondGroupDto dto,
        CancellationToken cancellationToken);
}

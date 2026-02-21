using Mehr.Application.Zones.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.Zones.Contracts;

public interface IZoneService
{
    Task<GetZoneDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Result<GetZoneDto>> GetByCodeAsync(int id, CancellationToken cancellationToken);
    Task<List<GetZoneDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<Result<int>> AddAsync(AddZoneDto dto, CancellationToken cancellationToken);
    Task<Result<bool>> UpdateAsync(int id, UpdateZoneDto dto, CancellationToken cancellationToken);
    Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken);
}

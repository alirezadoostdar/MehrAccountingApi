using Mehr.Application.Zons.Contracts.Dtos;

namespace Mehr.Application.Zons.Contracts;

public interface IZoneService
{
    Task<GetZoneDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<GetZoneDto>> GetAllAsync(CancellationToken cancellationToken);
    int AddAsync(AddZoneDto dto);
    void UpdateAsync(UpdateZoneDto dto);
    void DeleteAsync(int id);
}

using Mehr.Application.Zons.Contracts.Dtos;

namespace Mehr.Application.Zons.Contracts;

public interface IZoneService
{
    GetZoneDto GetByIdAsync(int id);
    List<GetZoneDto> GetAllAsync();

    int AddAsync(AddZoneDto dto);
    void UpdateAsync(UpdateZoneDto dto);
    void DeleteAsync(int id);
}

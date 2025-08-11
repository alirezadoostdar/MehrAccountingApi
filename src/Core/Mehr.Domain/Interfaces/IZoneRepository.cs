using Mehr.Domain.Entities.Contacts;

namespace Mehr.Domain.Interfaces;

public interface IZoneRepository
{
    Task<Zone?> GetByIdAsync(int id);
    Task<List<Zone>> GetAllAsync();
    Task AddAsync(Zone zone);
    void UpdateAsync(Zone zone);
    void Delete(Zone zone);
}

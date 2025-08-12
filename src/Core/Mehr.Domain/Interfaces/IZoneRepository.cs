using Mehr.Domain.Entities.Contacts;

namespace Mehr.Domain.Interfaces;

public interface IZoneRepository
{
    Task<Zone?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Zone>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Zone zone);
    void UpdateAsync(Zone zone);
    void Delete(Zone zone);
}

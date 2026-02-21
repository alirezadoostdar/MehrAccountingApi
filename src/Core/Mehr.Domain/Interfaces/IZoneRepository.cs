using Mehr.Domain.Entities.Contacts;

namespace Mehr.Domain.Interfaces;

public interface IZoneRepository
{
    Task<Zone?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Zone?> GetByTitleAsync(string title, CancellationToken cancellationToken);
    Task<List<Zone>> GetAllAsync(CancellationToken cancellationToken);
    Task<int> AddAsync(Zone zone);
    void UpdateAsync(Zone zone);
    void Delete(Zone zone);
}

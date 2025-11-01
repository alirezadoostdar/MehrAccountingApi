using Mehr.Domain.Entities.Docs;

namespace Mehr.Domain.Interfaces.Docs;

public interface IDocRepository
{
    Task<Doc> GetByIdAsync(int id);
}

using Mehr.Domain.Entities.Docs;
using Mehr.Domain.Interfaces.Docs;

namespace Mehr.Infarstructure.Docs;

public class EfDocRepository : IDocRepository
{
    private readonly ApplicationDbContext _context;

    public EfDocRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Doc> GetByIdAsync(int id)
    {
        return await _context.do ;
    }
}

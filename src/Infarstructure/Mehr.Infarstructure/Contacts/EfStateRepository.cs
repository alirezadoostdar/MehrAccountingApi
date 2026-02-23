using Mehr.Domain.Contacts;
using Mehr.Domain.Contacts.Contracts;
using Mehr.Domain.Contacts.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Contacts;

public class EfStateRepository : IStateRepository
{
    private readonly ApplicationDbContext _context;

    public EfStateRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetStateDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.States
            .Select(x => new GetStateDto
            {
                Id = x.Id,
                Title = x.Title,
            }).ToListAsync(cancellationToken);
    }
}

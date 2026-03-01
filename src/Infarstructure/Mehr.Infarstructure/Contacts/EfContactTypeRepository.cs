using Mehr.Domain.Contacts.Contracts;
using Mehr.Domain.Contacts.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Contacts;

public class EfContactTypeRepository : IContactTypeRepository
{
    private readonly ApplicationDbContext _context;

    public EfContactTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetContactTypeDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.ContactTypes
            .Select(x => new GetContactTypeDto
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync(cancellationToken);
    }
}

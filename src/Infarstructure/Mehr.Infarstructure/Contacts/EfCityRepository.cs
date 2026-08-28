using Mehr.Domain.Contacts.Contracts;
using Mehr.Domain.Contacts.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Contacts;

public class EfCityRepository : ICityRepository
{
    private readonly ApplicationDbContext _context;

    public EfCityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetCityDto>> GetAllAsync(int stateId, CancellationToken cancellationToken)
    {
        if (stateId == 0)
        {
            return await _context.Cities
                .Select(x => new GetCityDto
                {
                    Id = x.Id,
                    Title = x.Title,
                }).ToListAsync(cancellationToken);
        }

        return await _context.Cities.Where(x => x.StateId == stateId)
            .Select(x => new GetCityDto
            {
                Id = x.Id,
                Title = x.Title,
            }).ToListAsync(cancellationToken);
    }
}

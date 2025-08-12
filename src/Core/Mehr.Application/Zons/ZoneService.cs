using Mehr.Application.Zons.Contracts;
using Mehr.Application.Zons.Contracts.Dtos;
using Mehr.Domain;
using Mehr.Domain.Entities.Contacts;
using Mehr.Domain.Interfaces;

namespace Mehr.Application.Zons;

public class ZoneService : IZoneService
{
    private readonly IZoneRepository _zoneRepository;
    private readonly IUnitOfWork _uow;

    public ZoneService(IZoneRepository zoneRepository, IUnitOfWork uow)
    {
        _zoneRepository = zoneRepository;
        _uow = uow;
    }

    public int AddAsync(AddZoneDto dto)
    {
        throw new NotImplementedException();
    }

    public void DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GetZoneDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var list = await _zoneRepository.GetAllAsync(cancellationToken);
           return list.Select(x => new GetZoneDto
           {
               Id = x.Id,
               Title = x.Title,
           }).ToList();
    }

    public async Task<GetZoneDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            throw new Exception("sdfsdgdg");
        }
        var zone = await _zoneRepository.GetByIdAsync(id, cancellationToken);
        if (zone is null)
            throw new NotFoundException(nameof(Zone),id);

        return new GetZoneDto { 
            Id = zone.Id, 
            Title = zone.Title};
    }

    public void UpdateAsync(UpdateZoneDto dto)
    {
        throw new NotImplementedException();
    }
}

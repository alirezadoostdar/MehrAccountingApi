using Mehr.Application.Zones.Contracts;
using Mehr.Application.Zones.Contracts.Dtos;
using Mehr.Domain;
using Mehr.Domain.Entities.Contacts;
using Mehr.Domain.Interfaces;
using Mehr.SharedKernel;

namespace Mehr.Application.Zones;

public class ZoneService : IZoneService
{
    private readonly IZoneRepository _zoneRepository;
    private readonly IUnitOfWork _uow;

    public ZoneService(IZoneRepository zoneRepository, IUnitOfWork uow)
    {
        _zoneRepository = zoneRepository;
        _uow = uow;
    }

    public async Task<Result<int>> AddAsync(AddZoneDto dto, CancellationToken cancellationToken)
    {
        var zone = await _zoneRepository.GetByTitleAsync(dto.Title, cancellationToken);
        if (zone is not null)
            return Result.Failure<int>(ZoneErrors.DuplicateTitle(dto.Title));

        var id = await _zoneRepository.AddAsync(new Zone { Title = dto.Title });
        return id;
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
            throw new Exception(nameof(Zone));

        return new GetZoneDto
        {
            Id = zone.Id,
            Title = zone.Title
        };
    }

    public async Task<Result<GetZoneDto>> GetByCodeAsync(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            throw new Exception("sdfsdgdg");
        }
        var zone = await _zoneRepository.GetByIdAsync(id, cancellationToken);
        if (zone is null)
            return Result.Failure<GetZoneDto>(ZoneErrors.NotFound(id));

        return new GetZoneDto
        {
            Id = zone.Id,
            Title = zone.Title
        };
    }

    public void UpdateAsync(UpdateZoneDto dto)
    {
        throw new NotImplementedException();
    }
}

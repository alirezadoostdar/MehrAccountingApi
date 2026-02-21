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

        var newZone = new Zone { Title = dto.Title };
        await _zoneRepository.AddAsync(newZone, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
        return newZone.Id;
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

    public async Task<Result<bool>> UpdateAsync(int id, UpdateZoneDto dto, CancellationToken cancellationToken)
    {
        var zone = await _zoneRepository.GetByIdAsync(id, cancellationToken);
        if (zone is null)
            return Result.Failure<bool>(ZoneErrors.NotFound(id));

        var zoneByTitle = await _zoneRepository.GetByTitleAsync(dto.Title, cancellationToken);
        if (zoneByTitle is not null && zoneByTitle.Id != id)
            return Result.Failure<bool>(ZoneErrors.DuplicateTitle(dto.Title));

        zone.Title = dto.Title;
        _zoneRepository.Update(zone);
        await _uow.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var zone = await _zoneRepository.GetByIdAsync(id, cancellationToken);
        if (zone is null)
            return Result.Failure<bool>(ZoneErrors.NotFound(id));

        _zoneRepository.Delete(zone);
        await _uow.SaveChangesAsync(cancellationToken);
        return true;
    }
}

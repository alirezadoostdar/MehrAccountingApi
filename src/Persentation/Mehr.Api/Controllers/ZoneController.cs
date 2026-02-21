using Mehr.Application.Zones.Contracts;
using Mehr.Application.Zones.Contracts.Dtos;
using Mehr.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/zone")]
public class ZoneController : Controller
{
    private readonly IZoneService _zoneService;

    public ZoneController(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }

    [HttpGet]
    public async Task<List<GetZoneDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _zoneService.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetZoneDto>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var zone = await _zoneService.GetByIdAsync(id, cancellationToken);

        return Ok(zone);
    }

    [HttpPost]
    public async Task<ActionResult<Result>> AddAsync(AddZoneDto dto, CancellationToken cancellationToken)
    {
        return await _zoneService.AddAsync(dto, cancellationToken);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Result>> UpdateAsync(int id, UpdateZoneDto dto, CancellationToken cancellationToken)
    {
        return await _zoneService.UpdateAsync(id,dto, cancellationToken);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Result>> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return await _zoneService.DeleteAsync(id,cancellationToken);
    }
}

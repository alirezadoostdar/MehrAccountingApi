using Mehr.Application.Zons.Contracts;
using Mehr.Application.Zons.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("GetByCode/{id:int}")]
    public async Task<>
}

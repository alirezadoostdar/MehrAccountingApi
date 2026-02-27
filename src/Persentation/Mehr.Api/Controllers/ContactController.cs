using Mehr.Application.Contacts.Contracts;
using Mehr.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/contact")]
public class ContactController : Controller
{
    private readonly IContactService _service;

    public ContactController(IContactService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Result>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _service.GetByIdAsync(id, cancellationToken);
    }

    [HttpGet("state")]
    public async Task<ActionResult<Result>> GetAllStateAsync(CancellationToken cancellationToken)
    {
        return await _service.GetAllStateAsync(cancellationToken);
    }

    [HttpGet("city/{stateId:int}")]
    public async Task<ActionResult<Result>> GetAllCitiesAsync(int stateId, CancellationToken cancellationToken)
    {
        return await _service.GetAllCityAsync(stateId, cancellationToken);
    }
}

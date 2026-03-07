using Mehr.Application.Contacts.Contracts;
using Mehr.Application.Contacts.Contracts.Dtos;
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


    [HttpGet("contact-type")]
    public async Task<ActionResult<Result>> GetAllContactTypeAsync(CancellationToken cancellationToken)
    {
        return await _service.GetAllContactTypeAsync(cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<Result>> AddContactAsync(AddContactDto dto, CancellationToken cancellationToken)
    {

    }
}

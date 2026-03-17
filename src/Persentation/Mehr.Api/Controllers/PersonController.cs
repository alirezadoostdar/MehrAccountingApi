using Mehr.Application.Persons.Contracts;
using Mehr.Application.Persons.Contracts.Dtos;
using Mehr.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/person")]
public class PersonController : Controller
{
    private readonly IPersonService _service;

    public PersonController(IPersonService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Result>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _service.GetByIdAsync(id, cancellationToken);
    }
    #region first-group

    [HttpGet("first-group")]
    public async Task<ActionResult<Result>> GetAllFirstGroupAsync(CancellationToken cancellationToken)
    {
        return await _service.GetAllFirtGroupAsync(cancellationToken);
    }

    [HttpPost("first-group")]
    public async Task<ActionResult<Result>> AddFirstGroupAsync( 
        AddPersonFirstGroupDto dto ,
        CancellationToken cancellationToken)
    {
        return await _service.AddFirstGroupAsync(dto, cancellationToken);
    }

    [HttpPut("first-group/{id:int}")]
    public async Task<ActionResult<Result>> UpdateFirstGroupAsync(int id,
        UpdatePersonFirstGroupDto dto,
        CancellationToken cancellationToken)
    {
        return await _service.UpdateFirstGroupAsync(id, dto, cancellationToken);
    }

    [HttpDelete("first-group/{id:int")]
    public async Task<ActionResult<Result>> DeleteFirstGroupAsync(int id, CancellationToken cancellationToken)
    {
        return await _service.DeleteFirstGroupAsync(id, cancellationToken);
    }
    #endregion
}

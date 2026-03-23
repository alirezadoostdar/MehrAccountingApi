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

    [HttpGet("first-group/{id:int}")]
    public async Task<ActionResult<Result>> GetFirstGroupByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _service.GetFirstGroupByIdAsync(id, cancellationToken);
    }

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

    [HttpDelete("first-group/{id:int}")]
    public async Task<ActionResult<Result>> DeleteFirstGroupAsync(int id, CancellationToken cancellationToken)
    {
        return await _service.DeleteFirstGroupAsync(id, cancellationToken);
    }
    #endregion

    #region second-group

    [HttpGet("second-group/{id:int}")]
    public async Task<ActionResult<Result>> GetSecondGroupByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _service.GetSecondGroupByIdAsync(id, cancellationToken);
    }

    [HttpGet("second-group")]
    public async Task<ActionResult<Result>> GetAllSecondGroupAsync(CancellationToken cancellationToken)
    {
        return await _service.GetAllSecondGroupAsync(cancellationToken);
    }

    [HttpPost("second-group")]
    public async Task<ActionResult<Result>> AddSecondGroupAsync(
        AddPersonSecondGroupDto dto,
        CancellationToken cancellationToken)
    {
        return await _service.AddSecondGroupAsync(dto, cancellationToken);
    }

    [HttpPut("second-group/{id:int}")]
    public async Task<ActionResult<Result>> UpdateSecondGroupAsync(int id,
        UpdatePersonSecondGroupDto dto,
        CancellationToken cancellationToken)
    {
        return await _service.UpdateSecondGroupAsync(id, dto, cancellationToken);
    }

    [HttpDelete("second-group/{id:int}")]
    public async Task<ActionResult<Result>> DeleteSecondGroupAsync(int id, CancellationToken cancellationToken)
    {
        return await _service.DeleteSecondGroupAsync(id, cancellationToken);
    }
    #endregion
}

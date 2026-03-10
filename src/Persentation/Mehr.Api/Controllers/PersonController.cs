using Mehr.Application.Persons.Contracts;
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
    #endregion
}

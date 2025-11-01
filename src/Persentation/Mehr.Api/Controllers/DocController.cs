using Mehr.Application.Docs.Contracts;
using Mehr.SharedKernel;
using Microsoft.AspNetCore.Mvc; 

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/docs")]
public class DocController : Controller
{
    private readonly IDocService _service;

    public DocController(IDocService service)
    {
        _service = service;
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Result>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _service.GetByIdAsync(id, cancellationToken);
    }

}

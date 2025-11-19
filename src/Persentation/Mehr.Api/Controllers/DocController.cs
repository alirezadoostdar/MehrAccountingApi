using Mehr.Application.Docs.Contracts;
using Mehr.Domain.Docs.Contracts.Dtos;
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


    [HttpGet("detail-account/{detailAccountId:int}/financial-year/{financialYearId:int}")]
    public async Task<ActionResult<Result>> GetDocRowsAsync(int detailAccountId,
        int financialYearId,
        CancellationToken cancellationToken,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20)
    {
        return await _service.GetDocItemOfDetailAccountAsync(detailAccountId,financialYearId
            ,page,pageSize,cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<Result>> AddAsync(AddDocDto dto, CancellationToken cancellationToken)
    {
        return await _service.AddAsync(dto, cancellationToken);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Result>> UpdaeAsync(int id, UpdateDocDto dto, CancellationToken cancellationToken)
    {
        return await _service.UpdateAsync(id, dto, cancellationToken);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Result>> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return await _service.DeleteAsync(id, cancellationToken);
    }
}

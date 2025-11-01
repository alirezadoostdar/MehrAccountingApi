using Mehr.Application.FinancialYears.Contracts;
using Mehr.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/finanialyears")]
public class FinancialYearController : Controller
{
    private readonly IFinancialYearService _service;

    public FinancialYearController(IFinancialYearService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<Result>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _service.GetAllAsync(cancellationToken);
    }

}

using Mehr.Application.DetailedAccounts.Contracts;
using Mehr.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/detailedaccounts")]
public class DetailedAccountController : Controller
{
    private readonly IDetailedAccountService _detailedAccountService;

    public DetailedAccountController(IDetailedAccountService detailedAccountService)
    {
        _detailedAccountService = detailedAccountService;
    }

    [HttpGet]
    public async Task<ActionResult<Result>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _detailedAccountService.GetAllAsync(cancellationToken);    
    }
}

using Mehr.SharedKernel;
using Microsoft.AspNetCore.Mvc; 

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/authentication")]
public class UserController : Controller
{


    [HttpGet]
    public async Task<ActionResult<Result>> GetUser(int id, CancellationToken cancellationToken)
    {

    }
}

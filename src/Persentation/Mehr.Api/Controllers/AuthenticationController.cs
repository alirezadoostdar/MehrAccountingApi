using Microsoft.AspNetCore.Mvc; 

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

using Microsoft.AspNetCore.Mvc; 

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/authentication")]
public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

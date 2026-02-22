using Microsoft.AspNetCore.Mvc;

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/contact")]
public class ContactController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}

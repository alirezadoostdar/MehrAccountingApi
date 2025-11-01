using Microsoft.AspNetCore.Mvc;

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/finanialyears")]
public class FinancialYearController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}

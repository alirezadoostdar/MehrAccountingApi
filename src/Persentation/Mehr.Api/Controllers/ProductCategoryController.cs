using Mehr.Application.Intrefaces;
using Mehr.Domain.Dtos.ProdcutCategory;
using Microsoft.AspNetCore.Mvc;

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/productCategories")]
public class ProductCategoryController : Controller
{
    private readonly IProductCategoryService _service;

    public ProductCategoryController(IProductCategoryService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(AddProductCategoryDto dto)
    {
        var result = await _service.AddAsync(dto);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllAsync()
    {
        return Ok(await _service.GetAllAsync());
    }
}

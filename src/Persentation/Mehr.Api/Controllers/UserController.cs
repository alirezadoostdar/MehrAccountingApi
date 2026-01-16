using Mehr.Application.ApiValidate.Contracts;
using Mehr.Application.Users.Contracts;
using Mehr.Domain.Users.Contracts.Dtos;
using Mehr.SharedKernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : Controller
{
    private readonly IUserService _service;
    private readonly IApiValidateService _apiValidateService;
    public UserController(IUserService service,IApiValidateService apiValidateService)
    {
        _service = service;
        _apiValidateService = apiValidateService;
    }

    [HttpGet("{id:int}")]
    [Authorize(Policy = "200")]
    public async Task<ActionResult<Result>> GetUser(int id, CancellationToken cancellationToken)
    {
        return await _service.GetUserById(id, cancellationToken);
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult<Result>> Authenticate(UserLoginDto dto, CancellationToken cancellationToken)
    {
        var res = await _service.UserLoginAsync(dto, cancellationToken);
        return res;
    }
}

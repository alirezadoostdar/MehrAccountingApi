using Mehr.Application.Contacts.Contracts;
using Mehr.Application.Contacts.Contracts.Dtos;
using Mehr.Application.Users;
using Mehr.Infarstructure.Identity;
using Mehr.SharedKernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mehr.Api.Controllers;

[ApiController]
[Route("api/contact")]
[Authorize]
public class ContactController : Controller
{
    private readonly IContactService _service;

    public ContactController(IContactService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Result>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _service.GetByIdAsync(id, cancellationToken);
    }

    [HttpGet("state")]
    public async Task<ActionResult<Result>> GetAllStateAsync(CancellationToken cancellationToken)
    {
        return await _service.GetAllStateAsync(cancellationToken);
    }

    [HttpGet("city/{stateId:int}")]
    public async Task<ActionResult<Result>> GetAllCitiesAsync(int stateId, CancellationToken cancellationToken)
    {
        return await _service.GetAllCityAsync(stateId, cancellationToken);
    }


    [HttpGet("contact-type")]
    public async Task<ActionResult<Result>> GetAllContactTypeAsync(CancellationToken cancellationToken)
    {
        return await _service.GetAllContactTypeAsync(cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<Result>> AddContactAsync(AddContactDto dto, CancellationToken cancellationToken)
    {
        return await _service.AddContactAsync(dto, cancellationToken);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Result>> UpdateContactAsync(int id, UpdateContactDto dto,
        CancellationToken cancellationToken)
    {
        return await _service.UpdateContactAsync(id, dto, cancellationToken);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Result>> DeleteContactAsync(int id, CancellationToken cancellation)
    {
        return await _service.DeleteContactAsync(id, cancellation);
    }

    [HttpGet("page:{int},pageSize:{int},search:{string},sortBy:{string},sortDesc:{bool}")]
    [HasPermission(MehrPolicy.Grid_Contact_List)]
    public async Task<ActionResult<Result>> GetAllContactsAsync(
        int page,
        int pageSize,
        string search,
        string sortBy,
        bool sortDesc,
        CancellationToken cancellationToken)
    {
        var x = page + pageSize;
        return await _service.GetAllContactListAsync(cancellationToken);
    }
}

public record GetContactsQuery(
    int Page = 1,
    int PageSize = 20,
    string? Search = null
);
public record PagedResult<T>(
    List<T> Items,
    int TotalCount,
    int Page,
    int PageSize
);

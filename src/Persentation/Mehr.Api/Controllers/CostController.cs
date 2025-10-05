using Mehr.Application.Costs.Contracts;
using Mehr.Application.Costs.Contracts.Dtos;
using Mehr.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace Mehr.Api.Controllers
{
    [ApiController]
    [Route("api/costs")]
    public class CostController : Controller
    {
        private readonly ICostService _service;

        public CostController(ICostService service)
        {
            _service = service;
        }

        #region Cost
        [HttpPost]
        public async Task<ActionResult<Result>> AddAsync(AddCostDto dto, CancellationToken cancellationToken)
        {
            return await _service.AddAsync(dto, cancellationToken);
        }
        #endregion

        #region First Group
        [HttpPost("first-group")]
        public async Task<ActionResult<Result>> AddFirstGroupAsync(
            AddCostFristGroupDto dto,
            CancellationToken cancellationToken)
        {
            return await _service.AddFirstGroupAsync(dto, cancellationToken);
        }
        #endregion

        #region Second Group
        [HttpPost("second-group")]
        public async Task<ActionResult<Result>> AddSecondGroupAsync(
            AddCostSecondGroupDto dto,
            CancellationToken cancellationToken)
        {
            return await _service.AddSecondGroupAsync(dto, cancellationToken);
        }
        #endregion

    }
}

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

        [HttpGet("first-group")]
        public async Task<ActionResult<Result>> GetAllFirstGroupAsync(CancellationToken cancellationToken)
        {
            return await _service.GetAllFirstGroupAsync(cancellationToken);
        }

        [HttpDelete("first-group/{id:int}")]
        public async Task<ActionResult<Result>> DeleteFirstGroupAsync(int id, CancellationToken cancellationToken)
        {
            return await _service.DeleteFirstGroupAsync(id, cancellationToken);
        }

        [HttpPut("first-group/{id:int}")]
        public async Task<ActionResult<Result>> UpdateFirstGroupAsync(
            int id,
            UpdateCostFirstGroupDto dto,
            CancellationToken cancellationToken)
        {
            return await _service.UpdateCostFirstGroupAsync(id, dto, cancellationToken);
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

        [HttpGet("second-group")]
        public async Task<ActionResult<Result>> GetAllSecondGroupAsync(CancellationToken cancellationToken)
        {
            return await _service.GetAllSecondGroupAsync(cancellationToken);
        }

        [HttpDelete("second-group/{id:int}")]
        public async Task<ActionResult<Result>> DeleteSecondGroupAsync(int id, CancellationToken cancellationToken)
        {
            return await _service.DeleteSecondGroupAsync(id, cancellationToken);
        }

        [HttpPut("second-group/{id:int}")]
        public async Task<ActionResult<Result>> UpdateSecondGroupAsync(
            int id,
            UpdateCostSecondGroupDto dto,
            CancellationToken cancellationToken)
        {
            return await _service.UpdateCostSecondGroupAsync(id, dto, cancellationToken);
        }
        #endregion

    }
}

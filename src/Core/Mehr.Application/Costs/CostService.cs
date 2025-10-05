using Mehr.Application.Costs.Contracts;
using Mehr.Application.Costs.Contracts.Dtos;
using Mehr.Domain.Entities.Costs;
using Mehr.Domain.Interfaces.Costs;
using Mehr.SharedKernel;

namespace Mehr.Application.Costs;

public class CostService : ICostService
{
    private readonly ICostRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CostService(ICostRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> AddAsync(AddCostDto dto, CancellationToken cancellation)
    {
        var cost = new Cost
        {
            Title = dto.Title,
            CategoryId = 3,
            Comment = dto.Comment,
            CreditLimit = 100000,
            IsDebtor = true,
            SecureLevelId = (int)dto.SecureLevel,
            FirstGroupId = dto.FirstGroupId,
            SecondGroupId = dto.SecondGroupId,
        };
        await _repository.AddAsync(cost, cancellation);
        await _unitOfWork.SaveChangesAsync();
        return cost.Id;
    }


    public Task<Result<int>> AddFirstGroupAsync(AddCostFristGroupDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<int>> AddSecondGroupAsync(AddCostFristGroupDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

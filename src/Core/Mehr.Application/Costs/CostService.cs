using Mehr.Application.Costs.Contracts;
using Mehr.Application.Costs.Contracts.Dtos;
using Mehr.Domain.Entities.Banks;
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


    public async Task<Result<int>> AddFirstGroupAsync(AddCostFristGroupDto dto, CancellationToken cancellationToken)
    {
        var firstGroup = new CostFirstGroup
        {
            Title = dto.Title
        };

        await _repository.AddFirstGroupAsync(firstGroup, cancellationToken);
        await _unitOfWork.SaveChangesAsync();
        return firstGroup.Id;
    }

    public async Task<Result<int>> AddSecondGroupAsync(AddCostSecondGroupDto dto, CancellationToken cancellationToken)
    {
        var secondGroup = new CostSecondGroup
        {
            Title = dto.Title
        };

        await _repository.AddSecondGroupAsync(secondGroup, cancellationToken);
        await _unitOfWork.SaveChangesAsync();
        return secondGroup.Id;
    }

    public Task<Result<bool>> DeleteFirstGroupAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<GetCostFristGroupDto>>> GetAllFirstGroupAsync(CancellationToken cancellationToken)
    {
        var list = await _repository.GetAllFirstGroupAsync(cancellationToken);
        return list.Select(x => new GetCostFristGroupDto
        {
            Id = x.Id,
            Title = x.Title
        }).ToList();
    }

    public async Task<Result<List<GetCostSecondGroupDto>>> GetAllSecondGroupAsync(CancellationToken cancellationToken)
    {
        var list = await _repository.GetAllSecondGroupAsync(cancellationToken);
        return list.Select(x => new GetCostSecondGroupDto
        {
            Id = x.Id,
            Title = x.Title
        }).ToList();
    }
}

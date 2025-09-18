using Mehr.Application.DetailedAccounts.Contracts;
using Mehr.Application.DetailedAccounts.Contracts.Dtos;
using Mehr.Domain.Interfaces.DetailedAccounts;
using Mehr.SharedKernel;

namespace Mehr.Application.DetailedAccounts;

public class DetailedAccountService : IDetailedAccountService
{
    private readonly IDetailedAccountRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DetailedAccountService(IDetailedAccountRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public Task<Result<int>> AddAsync(AddDetailedAccountDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<GetDetailedAccountDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var DetaileList = await _repository.GetAllAsync(cancellationToken);

        var dtoList = DetaileList.Select(x => new GetDetailedAccountDto
        {
            Id = x.Id,
            Title = x.Title,
            SecureLevel = x.SecureLevel,
            IsDebtor = x.IsDebtor,
            CategoryId = x.CategoryId,
        }).ToList();
        return dtoList;
    }

    public Task<Result<GetDetailedAccountDto>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateAsync(int id, UpdateDetailedAccountDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

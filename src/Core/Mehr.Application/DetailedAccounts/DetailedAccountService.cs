using Mehr.Application.DetailedAccounts.Contracts;
using Mehr.Application.DetailedAccounts.Contracts.Dtos;
using Mehr.Application.DetailedAccounts.Contracts.Exceptions;
using Mehr.Application.Zones.Contracts.Dtos;
using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Accounts.Dtos;
using Mehr.Domain.Entities.Contacts;
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

    public async Task<Result<int>> AddAsync(AddDetailedAccountDto dto, CancellationToken cancellationToken)
    {
        var detailedAccount = new DetailedAccount
        {
            Title = dto.Title,
            CategoryId = dto.CategoryId,
            CreditLimit = dto.CreditLimit,
            SecureLevelId = (int)dto.SecureLevel,
            IsDebtor = dto.IsDebtor,
            IsUpdate = true
        };

        await _repository.AddAsync(detailedAccount, cancellationToken);
        await _unitOfWork.SaveChangesAsync();
        return detailedAccount.Id;
    }

    public Task<Result> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<GetDetailedAccountDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var DetaileList = await _repository.GetAllAsync(cancellationToken);
        return DetaileList;
    }

    public async Task<Result<GetDetailedAccountDto>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var account = await _repository.GetByIdAsync(id, cancellationToken);
        if (account is null)
            return Result.Failure<GetDetailedAccountDto>(DetailedAccountError.NotFound(id));

        return account;
    }

    public Task<Result> UpdateAsync(int id, UpdateDetailedAccountDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

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

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var account = await _repository.FindAsync(id, cancellationToken);
        if (account is null)
            return Result.Failure(DetailedAccountError.NotFound(id));

        _repository.Delete(account);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<List<GetDetailedAccountDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var DetaileList = await _repository.GetAllAsync(cancellationToken);
        return DetaileList;
    }

    public async Task<Result<GetDetailedAccountDto>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var xx = await _repository.FindAsync(id, cancellationToken);
        var account = await _repository.GetByIdAsync(id, cancellationToken);
        if (account is null)
            return Result.Failure<GetDetailedAccountDto>(DetailedAccountError.NotFound(id));
        xx.Title = account.Title;
        return account;
    }

    public async Task<Result> UpdateAsync(int id, UpdateDetailedAccountDto dto, CancellationToken cancellationToken)
    {
        var account = await _repository.FindAsync(id, cancellationToken);
        if (account is null)
            return Result.Failure(DetailedAccountError.NotFound(id));

        account.Title = dto.Title;
        account.SecureLevelId = (int)dto.SecureLevel;
        account.CreditLimit = dto.CreditLimit;
        account.IsDebtor = dto.IsDebtor;

        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}

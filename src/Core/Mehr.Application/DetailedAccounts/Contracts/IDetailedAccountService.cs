using Mehr.Application.DetailedAccounts.Contracts.Dtos;
using Mehr.Domain.Entities.Accounts.Dtos;
using Mehr.Domain.Interfaces.DetailedAccounts;
using Mehr.SharedKernel;

namespace Mehr.Application.DetailedAccounts.Contracts;

public interface IDetailedAccountService
{
    Task<Result<GetDetailedAccountDto>> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Result<List<GetDetailedAccountDto>>> GetAllAsync(CancellationToken cancellationToken);
    Task<Result<int>> AddAsync(AddDetailedAccountDto dto, CancellationToken cancellationToken);
    Task<Result> UpdateAsync(int id, UpdateDetailedAccountDto dto, CancellationToken cancellationToken);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken);
}

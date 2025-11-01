using Mehr.Domain.FinancialYears.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.FinancialYears.Contracts;

public interface IFinancialYearService
{
    Task<Result<List<GetFinancialYearDto>>> GetAllAsync(CancellationToken cancellationToken);
}

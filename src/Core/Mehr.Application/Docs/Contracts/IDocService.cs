using Mehr.Domain.Docs.Contracts.Dtos;
using Mehr.Domain.Paginations;
using Mehr.SharedKernel;

namespace Mehr.Application.Docs.Contracts;
public interface IDocService
{
    Task<Result<GetDocDto>> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Result<int>> AddAsync(AddDocDto dto, CancellationToken cancellationToken);
    Task<Result<bool>> UpdateAsync(int id, UpdateDocDto dto, CancellationToken cancellationToken);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<Result<PageResult<GetDocItemAccountDetailDto>>> GetDocItemOfDetailAccountAsync(
        int detailAccountId, int financialYearId, int page, int pageSize,
        CancellationToken cancellationToken);
}

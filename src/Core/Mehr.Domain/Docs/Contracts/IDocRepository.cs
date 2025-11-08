using Mehr.Domain.Docs;
using Mehr.Domain.Docs.Contracts.Dtos;
using Mehr.Domain.Paginations;

namespace Mehr.Domain.Docs.Contracts;

public interface IDocRepository
{
    Task<Doc?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Doc doc, CancellationToken cancellationToken);
    Task<PageResult<GetDocItemAccountDetailDto>> GetDocItemOfDetailAccountAsync(
        int detailAccountId, int financialYearId, int page, int pageSize,
        CancellationToken cancellationToken);
}

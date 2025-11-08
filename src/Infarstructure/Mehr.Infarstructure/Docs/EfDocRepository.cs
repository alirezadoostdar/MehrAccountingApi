using Mehr.Domain.Docs;
using Mehr.Domain.Docs.Contracts;
using Mehr.Domain.Docs.Contracts.Dtos;
using Mehr.Domain.Paginations;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Docs;

public class EfDocRepository : IDocRepository
{
    private readonly ApplicationDbContext _context;

    public EfDocRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Doc doc, CancellationToken cancellationToken)
    {
        await _context.Docs.AddAsync(doc, cancellationToken);
    }

    public async Task<Doc?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var doc = await _context.Docs.FindAsync(id, cancellationToken);
        return doc;
    }

    public async Task<PageResult<GetDocItemAccountDetailDto>> GetDocItemOfDetailAccountAsync(
        int detailAccountId, 
        int financialYearId,
        int page,
        int pageSize,
        CancellationToken cancellationToken)
    {
        var query = _context.DocItems.Where(x => x.DetailedAccountId == detailAccountId &&
            x.Doc.FinancialYearId == financialYearId);

        var totalItems = await query.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        var list = await query
            .OrderBy(x => x.Doc.Date)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new GetDocItemAccountDetailDto
            {
                DocId = x.DocId,
                DocItemId = x.Id,
                Date = x.Doc.Date,
                SecondDetailAccount = x.SecondDetailedAccount.Title,
                ShamsiDate = x.Doc.ShamsiDate,
                AmountIn = x.AmountIn,
                AmountOut = x.AmountOut,
                Archived = x.ArchiveName,
                Checked = false,
                CreateAt = x.Doc.CreateAt,
                Currency1 = x.CurrencyAmount1,
                Currency2 = x.CurrencyAmount2,
                Currency3 = x.CurrencyAmount3,
                User = x.Doc.User.UserName,
                Remain = 0
            }).ToListAsync();

        var pageResult = new PageResult<GetDocItemAccountDetailDto>
        {
            Date = list,
            Meta = new PaginationMeta
            {
                CurrentPage = page,
                TotalPages = totalPages,
                TotalItems = totalItems,
                PageSize = pageSize,
            }
        };

        return pageResult;
    }
}

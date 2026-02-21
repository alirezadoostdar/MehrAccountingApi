using Mehr.Application.Docs.Contracts;
using Mehr.Application.Docs.Contracts.Exceptions;
using Mehr.Domain.Docs;
using Mehr.Domain.Docs.Contracts;
using Mehr.Domain.Docs.Contracts.Dtos;
using Mehr.Domain.Paginations;
using Mehr.SharedKernel;
using Mehr.SharedKernel.Dates;

namespace Mehr.Application.Docs;

public class DocService : IDocService
{
    private readonly IDocRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DocService(IDocRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> AddAsync(AddDocDto dto, CancellationToken cancellationToken)
    {
        var doc = new Doc
        {
            ShamsiDate = dto.ShamsiDate,
            Date = dto.ShamsiDate.GregorianDateTime(),
            Comment = dto.Comment,
            ArchiveName = "",
            CreateShamsiAt = DateTime.Now.PersianDate(),
            FinancialYearId = 1,
            IsTemp = false,
            CreateAt = DateTime.Now,
            ModifiedAt = DateTime.Now,
            Lock = false,
            Type = 2,
            CurrencyBaseRate1 = 0,
            UserId = 1,
            CurrencyBaseRate2 = 0,
            CurrencyBaseRate3 = 0,
            CurrencyRate1Part2 = 0,
            CurrencyRate2Part2 = 0,
            CurrencyRate3Part2 = 0,
            Items = dto.Items.Select(x => new DocItem
            {
                DetailedAccountId = x.DetailedAccountId,
                AmountIn = x.AmountIn,
                AmountOut = x.AmountOut,
                LeadAccountId = x.LeadAccountId,
                ArchiveName = "",
                Comment = x.Comment,
                SecondDetailedAccountId = x.SecondDetailedAccountId,
                CurrencyAmount1 = 0,
                CurrencyAmount2 = 0,
                CurrencyAmount3 = 0,
                RowNumber = 1,
                IsMoeinRow = false,
                Check = false,
                IsVisitorAutoDoc = false,

            }).ToList()
        };
        await _repository.AddAsync(doc, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return doc.Id;
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var doc = await _repository.GetByIdAsync(id, cancellationToken);
        if(doc is null)
            return Result.Failure(DocErros.NotFound(id));

        _repository.Delete(doc);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result<GetDocDto>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var doc = await _repository.GetByIdAsync(id, cancellationToken);

        return new GetDocDto
        {
            Id = doc.Id,
            Comment = doc.Comment,
            ShamsiDate = doc.ShamsiDate,
        };
    }

    public async Task<Result<PageResult<GetDocItemAccountDetailDto>>> GetDocItemOfDetailAccountAsync(
        int detailAccountId, int financialYearId,
        int page, int pageSize,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetDocItemOfDetailAccountAsync(detailAccountId,
            financialYearId, page, pageSize, cancellationToken);
        return result;
    }

    public async Task<Result<bool>> UpdateAsync(int id, UpdateDocDto dto, CancellationToken cancellationToken)
    {
        var doc = await _repository.GetByIdAsync(id, cancellationToken);
        doc.Items.Add(new DocItem
        {
            Id = 0,
            AmountIn = 333333,
            AmountOut = 0,
            DetailedAccountId = 51,
            LeadAccountId = 150,
            SecondDetailedAccountId = 9,
            RowNumber = 3,
            IsMoeinRow = false,
            Check = false,
            IsVisitorAutoDoc = false,
            CurrencyAmount1 = 0,
            CurrencyAmount2 = 0,
            CurrencyAmount3 = 0,
            ArchiveName = "",
            Comment = "Test",
        });
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}

using Mehr.Application.FinancialYears.Contracts;
using Mehr.Domain.FinancialYears.Contracts;
using Mehr.Domain.FinancialYears.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.FinancialYears;

public class FinancialYearsService : IFinancialYearService
{
    private readonly IFinancialYearRepositrory _repositrory;
    private readonly IUnitOfWork _unitOfWork;

    public FinancialYearsService(IFinancialYearRepositrory repositrory, IUnitOfWork unitOfWork)
    {
        _repositrory = repositrory;
        _unitOfWork = unitOfWork;
    }

    
    public async Task<Result<List<GetFinancialYearDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var list = await _repositrory.GetAllAsync(cancellationToken);

        return list.Select(x => new GetFinancialYearDto
        {
            Id = x.Id,
            Title = x.Title,
            StartDate = x.StartDateShamsi,
            EndDate = x.EndDateShamsi
        }).ToList();
    }
}
 
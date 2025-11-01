namespace Mehr.Domain.FinancialYears.Contracts;

public interface IFinancialYearRepositrory
{
    Task<List<FinancialYear>> GetAllAsync(CancellationToken cancellation);
}

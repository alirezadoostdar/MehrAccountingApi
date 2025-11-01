namespace Mehr.Domain.FinancialYears.Contracts.Dtos;

public class GetFinancialYearDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
}

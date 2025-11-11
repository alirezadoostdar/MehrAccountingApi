namespace Mehr.Domain.Docs.Contracts.Dtos;

public class UpdateDocDto
{
    public string Comment { get; set; }
    public string ShamsiDate { get; set; }
    public string StringCode { get; set; }
    public long? NumericCode { get; set; }
    public byte FinancialYearId { get; set; }
    public int? ProjectId { get; set; }
    public List<UpdateDocItemDto> Items { get; set; } = new();
}

public class UpdateDocItemDto
{
    public int Id { get; set; }
    public int DetailedAccountId { get; set; }

    public decimal AmountIn { get; set; }
    public decimal AmountOut { get; set; }
    public int SecondDetailedAccountId { get; set; }
    public string Comment { get; set; }

    public int LeadAccountId { get; set; }

}
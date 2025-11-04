namespace Mehr.Domain.Docs.Contracts.Dtos;

public class AddDocDto
{
    public string Comment { get; set; }
    public string ShamsiDate { get; set; }
    public string StringCode { get; set; }
    public long? NumericCode { get; set; }
    public byte FinancialYearId { get; set; }
    public int? ProjectId { get; set; }
}

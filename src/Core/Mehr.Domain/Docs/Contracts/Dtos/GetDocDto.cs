namespace Mehr.Domain.Docs.Contracts.Dtos;

public class GetDocDto
{
    public int Id { get; set; }
    public string ShamsiDate { get; set; }
    public string Comment { get; set; }
    public List<GetDocItemDto> Items { get; set; } = new List<GetDocItemDto>();

}


public class GetDocItemDto
{
    public int Id { get; set; }
    public int RowNumber { get; set; }
    public string SecondAccount { get; set; }
    public string Comment { get; set; }
    public decimal AmountIn { get; set; }
    public decimal AmountOut { get; set; }
}
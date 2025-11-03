namespace Mehr.Domain.Docs.Contracts.Dtos;

public class GetDocItemAccountDetailDto
{
    public int DocId { get; set; }
    public int DocItemId { get; set; }
    public DateTime CreateAt { get; set; }
    public string ShamsiDate { get; set; }
    public DateTime Date { get; set; }
    public string User { get; set; }
    public bool Checked { get; set; }
    public string SecondDetailAccount { get; set; }
    public decimal AmountIn { get; set; }
    public decimal AmountOut { get; set; }
    public decimal Remain { get; set; }
    public decimal Currency1 { get; set; }
    public decimal Currency2 { get; set; }
    public decimal Currency3 { get; set; }
    public string Archived { get; set; }
}

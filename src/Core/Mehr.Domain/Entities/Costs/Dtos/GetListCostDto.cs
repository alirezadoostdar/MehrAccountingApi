namespace Mehr.Domain.Entities.Costs.Dtos;

public class GetListCostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstGroup { get; set; }
    public string SecondGroup { get; set; }
    public decimal Remain { get; set; }
    public string SecureLevel { get; set; }
    public decimal FirstCurrency { get; set; }
    public decimal SecondCurrency { get; set; }
    public decimal ThirdCurrency { get; set; }
    public decimal CreditLimit { get; set; }
    public string Comment { get; set; }
    public string LastDate { get; set; }
}

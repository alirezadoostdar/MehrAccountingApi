namespace Mehr.Domain.Entities.Accounts.Dtos;

public class GetDetailedAccountDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string SecureLevel { get; set; }
    public decimal CreditLimit { get; set; }
    public bool? IsDebtor { get; set; }
}

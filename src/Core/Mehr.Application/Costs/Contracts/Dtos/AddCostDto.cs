using Mehr.Domain.Entities.Accounts;

namespace Mehr.Application.Costs.Contracts.Dtos;

public class AddCostDto
{
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public decimal CreditLimit { get; set; }
    public SecureLevelType SecureLevel { get; set; }
    public bool IsDebtor { get; set; }
    public int GroupId1 { get; set; }
}

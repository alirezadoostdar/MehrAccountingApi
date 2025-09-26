using Mehr.Domain.Entities.Accounts;

namespace Mehr.Application.Costs.Contracts.Dtos;

public class GetCostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public SecureLevelType SecureLevel { get; set; }
    public string Comment { get; set; }
    public string FirstGroup { get; set; }
    public string SecondGroup { get; set; }
}

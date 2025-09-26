using Mehr.Domain.Entities.Accounts;

namespace Mehr.Application.Costs.Contracts.Dtos;

public class UpdateCostDto
{
    public string Title { get; set; }
    public SecureLevelType SecureLevel { get; set; }
    public string Comment { get; set; }
    public int FirstGroupId { get; set; }
    public int SecondGroupId { get; set; }
}

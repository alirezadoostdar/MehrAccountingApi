using Mehr.Domain.Entities.Accounts;

namespace Mehr.Application.DetailedAccounts.Contracts.Dtos;

public class GetDetailedAccountDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public SecureLevelType SecureLevel { get; set; }
    public bool IsDebtor { get; set; }
}
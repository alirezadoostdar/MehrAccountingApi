namespace Mehr.Domain.Entities.Accounts;

public class DetailedAccount
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public DetailedCategoryAccount Category { get; set; }
    public SecureLevelType SecureLevel { get; set; }
    public bool IsDebtor { get; set; }
    public bool IsUpdate { get; set; }

}
public enum SecureLevelType
{
    First = 0,
    Second = 1,
    Third = 2,
    Forth = 3
}


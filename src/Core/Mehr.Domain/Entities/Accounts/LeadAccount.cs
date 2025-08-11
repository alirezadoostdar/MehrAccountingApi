namespace Mehr.Domain.Entities.Accounts;
public class LeadAccount
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public LeadAccountType Type { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public bool IsLock { get; set; }
    public decimal Balance { get; set; }
    public SecureLevel SecureLevel { get; set; }
    public bool HasDetailedCategory { get; set; }
    public int DetailedId { get; set; }
    public int DetailedCategoryId { get; set; }
    public bool IsTemp { get; set; }
}

public enum LeadAccountType
{
    ZeroAccount = 0,
    FirstLevel = 1,
    SecondLevel = 2,
    ThirdLevel = 3,
    ForthLevel = 4,
    FifthLevel = 5
}


public enum SecureLevel
{
    First = 0,
    Second = 1,
    Third = 2,
    Forth = 3
}
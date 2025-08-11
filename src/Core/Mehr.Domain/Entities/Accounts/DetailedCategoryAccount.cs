namespace Mehr.Domain.Entities.Accounts;

public class DetailedCategoryAccount
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DetailedCategoryType Type { get; set; }
    public bool Private { get; set; }
    public bool IsDetailedCategory { get; set; }
}

public enum DetailedCategoryType
{
    Permanet = 1,
    Temporaty = 2,
    Control = 3
}
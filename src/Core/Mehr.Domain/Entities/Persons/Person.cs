using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Contacts;
using Mehr.Domain.Entities.Costs;

namespace Mehr.Domain.Entities.Persons;

public class Person : DetailedAccount
{
    public int FirstGroupId { get; set; }
    public PersonFirstGroup FirstGroup { get; set; }
    public int SecondGroupId { get; set; }
    public PersonSecondGroup SecondGroup { get; set; }
    public double VisitorPercent { get; set; }
    public string Comment { get; set; }
    public string Introducer { get; set; }
    public long Code { get; set; }
    public SellPriceType SellPriceTpye { get; set; }
    public int ContactInfoId { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public int VisitorCostId { get; set; }
    public Cost VisitorCost { get; set; }
    public decimal VisitorBaseAmount { get; set; }
    public decimal VisitorIncreaseAmount { get; set; }
    public double VisitorIncresePercent { get; set; }
    public bool VisitorAutoDoc { get; set; }
    public int MyProperty { get; set; }
}

public enum SellPriceType
{
    First = 0,
    Second = 1,
    Third = 2,
    Fourth = 3,
    Fifth = 4
}
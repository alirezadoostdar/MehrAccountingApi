using Mehr.Domain.Entities.Accounts;

namespace Mehr.Domain.Entities.Banks;

public class Bank : DetailedAccount
{
    public string AccountNumber { get; set; }
    public string Manager { get; set; }
    public int ContactId { get; set; }
    public string Comment { get; set; }
    public string CardNumber { get; set; }
    public string Iban { get; set; }
    public string PaySwitchNumber { get; set; }
    public string ShoppingNumber { get; set; }
    public string TerminalNumber { get; set; }
}

public class CostSecondGroup
{

}
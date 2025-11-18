using Mehr.Domain.Docs;

namespace Mehr.Domain.Banks;

public class BankDocItem : DocItem
{
    public string TransactionNumber { get; set; }
    public bool IsPos { get; set; }

    public override DocItemType GetItemType()
    {
        return DocItemType.Bank;
    }
}

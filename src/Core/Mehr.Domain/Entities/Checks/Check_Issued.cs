using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Banks;
using Mehr.Domain.Entities.Docs;

namespace Mehr.Domain.Entities.Checks;

public class Check_Issued : DocItem
{
    public long SerialNumber { get; set; }
    public string Comment { get; set; }
    public int BankId { get; set; }
    public Bank Bank { get; set; }
    public DateTime Date { get; set; }
    public string ShamsiDate { get; set; }
    public int PersonId { get; set; }
    public DetailedAccount Person{ get; set; }

}

using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Banks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mehr.Domain.Entities.Costs;

public class Cost : DetailedAccount
{
    //[Column("Fk_AccountSyscode")]
    public int Fk_AccountSyscode { get; set; }
    public int FirstGroupId { get; set; }
    public CostFirstGroup FirstGroup { get; set; }

    public int SecondGroupId { get; set; }
    public CostSecondGroup SecondGroup { get; set; }

    public string Comment { get; set; }
}

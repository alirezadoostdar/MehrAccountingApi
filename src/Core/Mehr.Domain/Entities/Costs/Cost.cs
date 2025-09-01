using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Entities.Banks;

namespace Mehr.Domain.Entities.Costs;

public class Cost : DetailedAccount
{
    public int MyProperty { get; set; }

    public int FirstGroupId { get; set; }
    public CostFirstGroup FirstGroup { get; set; }

    public int SecondGroupId { get; set; }
    public CostSecondGroup SecondGroup { get; set; }

    public string Comment { get; set; }
}

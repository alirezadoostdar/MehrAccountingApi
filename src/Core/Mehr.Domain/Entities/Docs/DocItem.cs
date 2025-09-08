using Mehr.Domain.Entities.Accounts;

namespace Mehr.Domain.Entities.Docs;

public class DocItem
{
    public int Id { get; set; }
    public int DocId { get; set; }
    public Doc Doc { get; set; }

    public int DetailedAccountId { get; set; }
    public DetailedAccount DetailedAccount { get; set; }

    public decimal AmountIn { get; set; }
    public decimal AmountOut { get; set; }
    public int RowNumber { get; set; }
    public string ArchiveName { get; set; }
    public int SecondDetailedAccountId { get; set; }
    public DetailedAccount SecondDetailedAccount { get; set; }
    public string Comment { get; set; }
    public decimal CurrencyAmount1 { get; set; }
    public decimal CurrencyAmount2 { get; set; }
    public decimal CurrencyAmount3 { get; set; }
    public bool Check { get; set; }
    public int VisitorId { get; set; }
    public DetailedAccount Visitor { get; set; }
    public bool IsVisitorAutoDoc { get; set; }
    public bool IsUpdate { get; set; }
    public int LeadAccountId { get; set; }
    public LeadAccount LeadAccount { get; set; }
    public bool IsMoeinRow { get; set; }
    public byte MoreType { get; set; }
}

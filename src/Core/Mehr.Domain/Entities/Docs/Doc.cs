using Mehr.Domain.Entities.FinancialYears;
using Mehr.Domain.Entities.Projects;
using Mehr.Domain.Entities.Users;
using Microsoft.Identity.Client;

namespace Mehr.Domain.Entities.Docs;

public class Doc
{
    public int Id { get; set; }
    public string ShamsiDate { get; set; }
    public DateTime Date { get; set; }

    public string CreateShamsiAt { get; set; }
    public DateTime CreateAt { get; set; }

    public int UserId { get; set; }
    public User User{ get; set; }

    public string Comment { get; set; }
    public string ArchiveName { get; set; }
    public bool Look { get; set; }
    public string StringCode { get; set; }
    public long NumericCode { get; set; }
    public decimal CurrencyBaseRate1 { get; set; }
    public decimal CurrencyBaseRate2 { get; set; }
    public decimal CurrencyBaseRate3 { get; set; }
    public decimal CurrencyRate1Part2 { get; set; }
    public decimal CurrencyRate2Part2 { get; set; }
    public decimal CurrencyRate3Part2 { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public DocType Type { get; set; }

    public bool IsTemp { get; set; }
    public int OpeningLeadAccountCode { get; set; }

    public int FinancialYearId { get; set; }
    public FinancialYear FinancialYear { get; set; }

    public int Code { get; set; }
    public DateTime ModifiedAd { get; set; }
    public ICollection<DocItem> Items { get; set; } = new List<DocItem>();
}

public enum DocType
{
    Opening = 1,
    Transaction = 2,
    Closing = 3
}
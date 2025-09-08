using Mehr.Domain.Entities.Docs;

namespace Mehr.Domain.Entities.FinancialYears;

public class FinancialYear
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDateMiladi { get; set; }
    public string StartDateShamsi { get; set; }
    public DateTime EndDateMiladi { get; set; }
    public string EndDateShamsi { get; set; }
    public DateTime RegisterDate { get; set; }
    public bool Active { get; set; }

    public ICollection<Doc> Docs{ get; set; } = new List<Doc>();
}

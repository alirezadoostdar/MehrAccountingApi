namespace Mehr.Domain.Stocks;

public class ProductGroup1
{
    public int Id { get; set; }
    public string Title { get; set; }

    public List<Prouduct> Products { get; set; } = new();
}

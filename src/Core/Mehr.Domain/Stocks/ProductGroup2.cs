namespace Mehr.Domain.Stocks;

public class ProductGroup2
{
    public int Id { get; set; }
    public string Title { get; set; }
    public float VisitPercent { get; set; }

    public List<Product> Products { get; set; } = new();
}
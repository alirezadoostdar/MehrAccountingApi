namespace Mehr.Domain.Stocks;

public class ProductGroup3
{
    public int Id { get; set; }
    public string Title { get; set; }

    public List<Product> Products { get; set; } = new();
}
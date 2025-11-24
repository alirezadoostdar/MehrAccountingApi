namespace Mehr.Domain.Stocks;

public class ProductCategory
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ParentId { get; set; }
    public ProductCategory Parent { get; set; }
    public byte[] Image { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<ProductCategory> Children { get; set; } = new List<ProductCategory>();

    public List<Product> Products { get; set; } = new();
}
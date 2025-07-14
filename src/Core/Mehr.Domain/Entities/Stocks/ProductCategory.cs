namespace Mehr.Domain.Entities.Stocks;

public class ProductCategory
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ParentId { get; set; }
    public ProductCategory Parent { get; set; }
    public byte[] Image { get; set; }
    public string ImageUrl { get; set; }

    public ICollection<ProductCategory> Children { get; set; } = new List<ProductCategory>();
}
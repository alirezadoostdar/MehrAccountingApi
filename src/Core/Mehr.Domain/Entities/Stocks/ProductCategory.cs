namespace Mehr.Domain.Entities.Stocks;

public class ProductCategory
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ParentId { get; set; }
    public byte[] Image { get; set; }
    public string ImageUrl { get; set; }
}
namespace Mehr.Domain.Stocks.Contracts;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
}

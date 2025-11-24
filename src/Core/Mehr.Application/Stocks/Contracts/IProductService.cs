using Mehr.Domain.Stocks;
using Mehr.SharedKernel;

namespace Mehr.Application.Stocks.Contracts;

public interface IProductService
{
    Task<Result<List<Product>>> GetAllAsync(CancellationToken cancellationToken);
}

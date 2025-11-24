using Mehr.Application.Stocks.Contracts;
using Mehr.Domain.Stocks;
using Mehr.Domain.Stocks.Contracts;
using Mehr.SharedKernel;

namespace Mehr.Application.Stocks;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<Product>>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}

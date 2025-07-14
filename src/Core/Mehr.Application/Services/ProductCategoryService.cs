using Mehr.Application.Intrefaces;
using Mehr.Domain.Dtos.ProdcutCategory;
using Mehr.Domain.Interfaces;

namespace Mehr.Application.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public Task<int> AddAsync(AddProductCategoryDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetProductCategoryDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetProductCategoryDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}

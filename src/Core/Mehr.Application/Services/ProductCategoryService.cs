using Mehr.Application.Intrefaces;
using Mehr.Domain.Dtos.ProdcutCategory;
using Mehr.Domain.Entities.Stocks;
using Mehr.Domain.Interfaces;

namespace Mehr.Application.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<int> AddAsync(AddProductCategoryDto dto)
    {
        var productCategory = new ProductCategory
        {
            Title = dto.Title,
            ParentId = dto.ParentId,
        };

        await _productCategoryRepository.AddAsync(productCategory);
        return 0;
    }

    public Task<List<GetProductCategoryDto>> GetAllAsync()
    {
        return _productCategoryRepository.GetAllAsync();
    }

    public Task<GetProductCategoryDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}

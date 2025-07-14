using Mehr.Domain.Dtos.ProdcutCategory;
using Mehr.Domain.Entities.Stocks;

namespace Mehr.Domain.Interfaces;

public interface IProductCategoryRepository
{
    Task AddAsync(ProductCategory productCategory);
    Task UpdateAsync(ProductCategory productCategory);
    Task DeleteAsync(int id);
    Task<ProductCategory> GetByIdAsync(int id);
    Task<List<GetProductCategoryDto>> GetAllAsync();
    Task<List<GetProductCategoryDto>> GetChildAsync(int parentId);
}

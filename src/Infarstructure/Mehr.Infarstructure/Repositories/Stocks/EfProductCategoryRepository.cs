using Mehr.Domain.Dtos.ProdcutCategory;
using Mehr.Domain.Entities.Stocks;
using Mehr.Domain.Interfaces;

namespace Mehr.Infarstructure.Repositories.Stocks;

public class EfProductCategoryRepository : IProductCategoryRepository
{
    private readonly ApplicationDbContext _context;

    public EfProductCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ProductCategory productCategory)
    {
        await _context.ProductCategories.AddAsync(productCategory);
        await _context.SaveChangesAsync();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetProductCategoryDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductCategory> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetProductCategoryDto>> GetChildAsync(int parentId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ProductCategory productCategory)
    {
        throw new NotImplementedException();
    }
}

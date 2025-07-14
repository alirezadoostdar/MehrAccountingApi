using Mehr.Domain.Dtos.ProdcutCategory;

namespace Mehr.Application.Intrefaces;

public interface IProductCategoryService
{
    Task<List<GetProductCategoryDto>> GetAllAsync();
    Task<GetProductCategoryDto> GetByIdAsync(int id);
    Task<int> AddAsync(AddProductCategoryDto dto);
}

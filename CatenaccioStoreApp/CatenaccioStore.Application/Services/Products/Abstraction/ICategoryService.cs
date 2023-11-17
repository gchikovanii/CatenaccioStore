using CatenaccioStore.Application.Services.Products.DTOs;

namespace CatenaccioStore.Application.Services.Products.Abstraction
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
        Task<bool> AddCategory(CancellationToken cancellationToken, CreateCategoryDto input);
        Task<bool> UpdateCategory(CancellationToken cancellationToken, string name, string newName);
        Task<bool> DeleteCategory(CancellationToken cancellationToken, string name);
    }
}

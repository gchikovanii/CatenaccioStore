using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using CatenaccioStore.Domain.Entities.Products;
using CatenaccioStore.Infrastructure.Repositories.Abstraction.Products;
using CatenaccioStore.Infrastructure.Units;
using Mapster;

namespace CatenaccioStore.Application.Services.Products.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAll();
            return result.Adapt<List<CategoryDto>>();
        }
        public async Task<bool> AddCategory(CancellationToken cancellationToken, CreateCategoryDto input)
        {
            await _categoryRepository.CreateAsync(cancellationToken,input.Adapt<Category>()).ConfigureAwait(false);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> UpdateCategory(CancellationToken cancellationToken, string name, string newName)
        {
            await _categoryRepository.UpdateAsync(cancellationToken,name,newName).ConfigureAwait(false);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteCategory(CancellationToken cancellationToken, string name)
        {
            await _categoryRepository.DeleteAsync(cancellationToken, name).ConfigureAwait(false);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

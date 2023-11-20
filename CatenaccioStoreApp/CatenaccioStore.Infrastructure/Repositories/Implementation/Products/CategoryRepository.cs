using CatenaccioStore.Domain.Entities.Products;
using CatenaccioStore.Infrastructure.Errors;
using CatenaccioStore.Infrastructure.Localizations;
using CatenaccioStore.Infrastructure.Repositories.Abstraction;
using CatenaccioStore.Infrastructure.Repositories.Abstraction.Products;
using Microsoft.EntityFrameworkCore;

namespace CatenaccioStore.Infrastructure.Repositories.Implementation.Products
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Category> _repository;

        public CategoryRepository(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _repository.Table.ToListAsync();
        }

        public async Task CreateAsync(CancellationToken cancellationToken, Category product)
        {
            await _repository.AddAsync(product, cancellationToken);
        }
        public async Task UpdateAsync(CancellationToken cancellationToken, string categoryName, string newName)
        {
            var entity = await _repository.Table.FirstOrDefaultAsync(i => i.Name.ToLower() == categoryName.ToLower());
            if (entity == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            entity.Name = newName;
            _repository.Update(entity, cancellationToken);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, string categoryName)
        {
            var entity = await _repository.Table.SingleOrDefaultAsync(i => i.Name.ToLower() == categoryName.ToLower());
            if (entity == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            await _repository.RemoveAsync(cancellationToken, entity.Id);
        }

    }
}

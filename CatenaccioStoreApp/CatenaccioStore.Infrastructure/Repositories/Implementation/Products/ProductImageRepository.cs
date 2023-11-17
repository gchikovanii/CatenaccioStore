using CatenaccioStore.Domain.Entities.Products;
using CatenaccioStore.Infrastructure.Errors;
using CatenaccioStore.Infrastructure.Repositories.Abstraction;
using CatenaccioStore.Infrastructure.Repositories.Abstraction.Products;
using Microsoft.EntityFrameworkCore;

namespace CatenaccioStore.Infrastructure.Repositories.Implementation.Products
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly IRepository<ProductImage> _productImageRepository;
        public ProductImageRepository(IRepository<ProductImage> productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        public async Task<ProductImage> GetProductImage(int id)
        {
            var result = await _productImageRepository.GetQuery(i => i.Id == id).SingleOrDefaultAsync();
            if (result == null)
                throw new NotFoundException("Not Found");
            return result;
        }
        public async Task<List<ProductImage>> GetAll()
        {
            return await _productImageRepository.Table.ToListAsync();
        }
        public async Task CreateAsync(CancellationToken cancellationToken, ProductImage productImage)
        {
            await _productImageRepository.AddAsync(productImage, cancellationToken);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, int imageId)
        {
            var entity = await _productImageRepository.Table.SingleOrDefaultAsync(i => i.Id == imageId);
            if (entity == null)
                throw new NotFoundException("Image doesn't exists");
            await _productImageRepository.RemoveAsync(cancellationToken, entity.Id);
        }

       
    }
}

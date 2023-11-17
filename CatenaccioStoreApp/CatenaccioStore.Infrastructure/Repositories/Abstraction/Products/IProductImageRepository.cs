using CatenaccioStore.Domain.Entities.Products;

namespace CatenaccioStore.Infrastructure.Repositories.Abstraction.Products
{
    public interface IProductImageRepository
    {
        Task<List<ProductImage>> GetAll();
        Task<ProductImage> GetProductImage(int id);
        Task CreateAsync(CancellationToken cancellationToken, ProductImage product);
        Task DeleteAsync(CancellationToken cancellationToken, int imageId);
    }
}

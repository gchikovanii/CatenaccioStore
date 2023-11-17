using CatenaccioStore.Domain.Entities.Products;

namespace CatenaccioStore.Infrastructure.Repositories.Abstraction.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts(CancellationToken cancellationToken);
        Task<Product> GetProductByName(CancellationToken cancellationToken, string name);
        Task<List<Product>> GetAllProductsPaginated(CancellationToken cancellationToken, int pageIndex, int pageSize);
        Task<List<Product>> GetAllProductsSortedBy(CancellationToken cancellationToken, string sort);
        Task<List<Product>> FilteredProducts(CancellationToken cancellationToken, string? brand, string? category);
        Task<List<Product>> SearchProducts(CancellationToken cancellationToken, string filter);
        Task CreateAsync(CancellationToken cancellationToken, Product product); 
        Task UpdateAsync(CancellationToken cancellationToken, Product product);
        Task DeleteAsync(CancellationToken cancellationToken, string name);
    }
}

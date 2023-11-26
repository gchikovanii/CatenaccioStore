using CatenaccioStore.Application.Services.Products.DTOs;
using CatenaccioStore.Domain.Entities.Products;
using Newtonsoft.Json.Linq;

namespace CatenaccioStore.Application.Services.Products.Abstraction
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProducts(CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllProductsPaginated(CancellationToken cancellationToken, int pageIndex, int pageSize);
        Task<int> GetAllProductsCount(CancellationToken token);
        Task<List<ProductDto>> GetAllProductsSortedBy(CancellationToken cancellationToken, string sort);
        Task<List<ProductDto>> FilteredProducts(CancellationToken cancellationToken, string? brand, string? category);
        Task<List<ProductDto>> SearchProducts(CancellationToken cancellationToken, string filter);
        Task<bool> AddProduct(CreationProductDto product, CancellationToken token);
        Task<bool> UpdateProductPrice(UpdateProductDto product, CancellationToken token);
        Task<bool> DeleteProduct(string productName, CancellationToken token);
    }
}

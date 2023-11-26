using CatenaccioStore.Domain.Entities.Products;
using CatenaccioStore.Infrastructure.Errors;
using CatenaccioStore.Infrastructure.Localizations;
using CatenaccioStore.Infrastructure.Repositories.Abstraction;
using CatenaccioStore.Infrastructure.Repositories.Abstraction.Products;
using Microsoft.EntityFrameworkCore;

namespace CatenaccioStore.Infrastructure.Repositories.Implementation.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepository<Product> _productRepository;
        public ProductRepository(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> GetAllProducts(CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetQuery().Include(i => i.Images).Include(i => i.Category).ToListAsync(cancellationToken);
            return result.ToList();
        }
        public async Task<Product> GetProductByName(CancellationToken cancellationToken, string name)
        {
            var result = await _productRepository.GetQuery(i => i.ProductName.ToLower() == name.ToLower()).SingleOrDefaultAsync(cancellationToken);
            if (result == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            return result;
        }
        public async Task<List<Product>> GetAllProductsPaginated(CancellationToken cancellationToken, int pageIndex, int pageSize)
        {
            var result = await _productRepository.GetQuery().Include(i => i.Category).Include(i => i.Images).Skip(pageSize * (pageIndex -1)).Take(pageSize).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<List<Product>> FilteredProducts(CancellationToken cancellationToken, string? brand, string? category)
        {
            var products = _productRepository.GetQuery().Include(i => i.Images).Include(i => i.Category);

            if (!String.IsNullOrEmpty(brand) && !String.IsNullOrEmpty(category))
            {
                await products.Where(i => i.Brand == brand && i.Category.Name == category).ToListAsync();
            }
            else if (String.IsNullOrEmpty(brand) && !String.IsNullOrEmpty(category))
            {
                await products.Where(i => i.Category.Name == category).ToListAsync();
            }
            else if (!String.IsNullOrEmpty(brand) && String.IsNullOrEmpty(category))
            {
                await products.Where(i => i.Brand == brand).ToListAsync();
            }
            return await products.ToListAsync(cancellationToken);
        }
        public async Task<List<Product>> GetAllProductsSortedBy(CancellationToken cancellationToken, string sort)
        {
            var products = _productRepository.GetQuery().Include(i => i.Category).Include(i => i.Images);
            if (sort == "desc")
            {
                await products.OrderByDescending(i => i.Price).ToListAsync();
            }
            else if (sort == "asc")
            {
                await products.OrderBy(i => i.Price).ToListAsync();
            }
            else
            {
                await products.OrderBy(i => i.ProductName).ToListAsync();
            }
            return await products.ToListAsync(cancellationToken);
        }
        public async Task<List<Product>> SearchProducts(CancellationToken cancellationToken, string filter)
        {
            var products = await _productRepository.GetQuery().Include(i => i.Category).Include(i => i.Images).Where(i => i.ProductName.ToLower().StartsWith(filter.ToLower())).ToListAsync();
            return products;
        }
        public async Task CreateAsync(CancellationToken cancellationToken, Product product)
        {
            var productExists = await _productRepository.GetQuery(i => i.ProductName == product.ProductName).SingleOrDefaultAsync(cancellationToken);
            if (productExists != null)
                throw new AlreadyExists(ErrorMessages.AlreadyExists);
            await _productRepository.AddAsync(product, cancellationToken);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, Product product)
        {
            var entity = await _productRepository.Table.FirstOrDefaultAsync(i => i.ProductName.ToLower() == product.ProductName.ToLower());
            if (entity == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            if(product.ProductName != null) 
                entity.ProductName = product.ProductName;
            if (product.Price != 0 )
                entity.Price = product.Price;
            if (product.CategoryId != 0)
                entity.CategoryId = product.CategoryId;
            _productRepository.Update(entity, cancellationToken);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, string name)
        {
            var entity = await _productRepository.Table.SingleOrDefaultAsync(i => i.ProductName.ToLower() == name.ToLower());
            if (entity == null)
                throw new NotFoundException(ErrorMessages.NotFound);
            await _productRepository.RemoveAsync(cancellationToken, entity.Id);
        }
    }
}

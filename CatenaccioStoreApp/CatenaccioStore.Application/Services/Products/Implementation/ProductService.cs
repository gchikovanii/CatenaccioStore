using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using CatenaccioStore.Domain.Entities.Products;
using CatenaccioStore.Infrastructure.Repositories.Abstraction.Products;
using CatenaccioStore.Infrastructure.Units;
using Mapster;

namespace CatenaccioStore.Application.Services.Products.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        
        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> GetAllProductsCount(CancellationToken token)
        {
            return await _repository.GetAllProductsCount(token);
        }
        public async Task<List<ProductDto>> GetAllProducts(CancellationToken cancellationToken)
        {
            var products =  await _repository.GetAllProducts(cancellationToken);
            return products?.Select(product => new ProductDto()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ShortTitle = product.ShortTitle,
                Description = product.Description,
                Brand = product.Brand,
                CategoryName = product.Category.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Images = product.Images.Select(i => new ProductImage()
                {
                    PublicId = i.PublicId,
                    Url = i.Url
                }).ToList()
            }).ToList();
        }
        public async Task<List<ProductDto>> FilteredProducts(CancellationToken cancellationToken, string? brand, string? category)
        {
            var products = await _repository.FilteredProducts(cancellationToken, brand, category);
            return products?.Select(product => new ProductDto()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ShortTitle = product.ShortTitle,
                Description = product.Description,
                Brand = product.Brand,
                CategoryName = product.Category.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Images = product.Images.Select(i => new ProductImage()
                {
                    PublicId = i.PublicId,
                    Url = i.Url
                }).ToList()
            }).ToList();
        }

        public async Task<List<ProductDto>> GetAllProductsPaginated(CancellationToken cancellationToken, int pageIndex, int pageSize)
        {
            var products = await _repository.GetAllProductsPaginated(cancellationToken, pageIndex, pageSize);
            return products?.Select(product => new ProductDto()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ShortTitle = product.ShortTitle,
                Description = product.Description,
                Brand = product.Brand,
                CategoryName = product.Category.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Images = product.Images.Select(i => new ProductImage()
                {
                    PublicId = i.PublicId,
                    Url = i.Url
                }).ToList()
            }).ToList();
        }

        public async Task<List<ProductDto>> GetAllProductsSortedBy(CancellationToken cancellationToken, string sort)
        {
            var products = await _repository.GetAllProductsSortedBy(cancellationToken, sort);
            return products?.Select(product => new ProductDto()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ShortTitle = product.ShortTitle,
                Description = product.Description,
                Brand = product.Brand,
                CategoryName = product.Category.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Images = product.Images.Select(i => new ProductImage()
                {
                    PublicId = i.PublicId,
                    Url = i.Url
                }).ToList()
            }).ToList();
        }

        public async Task<List<ProductDto>> SearchProducts(CancellationToken cancellationToken, string filter)
        {
            var products = await _repository.SearchProducts(cancellationToken, filter);
            return products?.Select(product => new ProductDto()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ShortTitle = product.ShortTitle,
                Description = product.Description,
                Brand = product.Brand,
                CategoryName = product.Category.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Images = product.Images.Select(i => new ProductImage()
                {
                    PublicId = i.PublicId,
                    Url = i.Url
                }).ToList()
            }).ToList();
        }

        public async Task<bool> AddProduct(CreationProductDto product, CancellationToken token)
        {
            await _repository.CreateAsync(token, product.Adapt<Product>());
            var result = await _unitOfWork.SaveChangesAsync(token); 
            return result;
        }

        public async Task<bool> UpdateProductPrice(UpdateProductDto product, CancellationToken token)
        {
            await _repository.UpdateAsync(token, product.Adapt<Product>());
            var result = await _unitOfWork.SaveChangesAsync(token);
            return result;
        }
        public async Task<bool> DeleteProduct(string productName, CancellationToken token)
        {
            await _repository.DeleteAsync(token, productName);
            var result = await _unitOfWork.SaveChangesAsync(token);
            return result;
        }

       
    }
}

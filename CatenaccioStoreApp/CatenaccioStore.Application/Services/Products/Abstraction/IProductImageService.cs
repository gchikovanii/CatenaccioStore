using CatenaccioStore.Application.Services.Products.DTOs;

namespace CatenaccioStore.Application.Services.Products.Abstraction
{
    public interface IProductImageService
    {
        Task<List<ProductImageDto>> GetAll(CancellationToken cancellationToken);
        Task<bool> AddImage(CancellationToken cancellationToken, CreateProductImageDto input);
        Task<bool> AddImages(CancellationToken cancellationToken, CreateProductImagesDto input);
        Task<bool> DeleteImage(CancellationToken cancellationToken, int id);
    }
}

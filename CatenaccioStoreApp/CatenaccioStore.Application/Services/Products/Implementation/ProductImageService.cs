using CatenaccioStore.Application.Services.Cloudinaries.Abstraction;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using CatenaccioStore.Domain.Entities.Products;
using CatenaccioStore.Infrastructure.Errors;
using CatenaccioStore.Infrastructure.Repositories.Abstraction.Products;
using CatenaccioStore.Infrastructure.Units;
using Mapster;


namespace CatenaccioStore.Application.Services.Products.Implementation
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinary;

        public ProductImageService(IProductImageRepository productImageRepository, IUnitOfWork unitOfWork, ICloudinaryService cloudinary, IProductRepository productRepository)
        {
            _productImageRepository = productImageRepository;
            _unitOfWork = unitOfWork;
            _cloudinary = cloudinary;
            _productRepository = productRepository;
        }
        public async Task<List<ProductImageDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _productImageRepository.GetAll();
            return result.Adapt<List<ProductImageDto>>();
        }
        public async Task<bool> AddImage(CancellationToken cancellationToken, CreateProductImageDto input)
        {
            var product = await _productRepository.GetProductByName(cancellationToken,input.ProductName);
            var uplaodImage = await _cloudinary.UploadImage(input.File);
            await _productImageRepository.CreateAsync(cancellationToken, new ProductImage()
            {
                PublicId = uplaodImage.PublicId,
                Url = uplaodImage.Url.AbsoluteUri,
                ProductId = product.Id
            });
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (uplaodImage == null)
            {
                throw new ImageNotUploadedException("Failed to upload image!" + (result == true ? "Image added to database" : "Failed to add to database"));
            }
            return result;
        }
        public async Task<bool> AddImages(CancellationToken cancellationToken, CreateProductImagesDto input)
        {
            var product = await _productRepository.GetProductByName(cancellationToken,input.ProductName);
            var uplaodImage = await _cloudinary.UploadImages(input.Files);
            foreach (var image in uplaodImage)
            {
                await _productImageRepository.CreateAsync(cancellationToken, new ProductImage()
                {
                    PublicId = image.PublicId,
                    Url = image.Url.AbsoluteUri,
                    ProductId = product.Id
                });
            }
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (uplaodImage == null)
            {
                throw new ImageNotUploadedException("Failed to upload images!" + (result == true ? "Image added to database" : "Failed to add to database"));
            }
            return result;
        }
        public async Task<bool> DeleteImage(CancellationToken cancellationToken, int imageId)
        {
            var productImage = await _productImageRepository.GetProductImage(imageId);
            var deleteImage = await _cloudinary.DeleteImage(productImage.PublicId);
            await _productImageRepository.DeleteAsync(cancellationToken, imageId);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (deleteImage == null)
            {
                throw new ImageNotDeletedException("Failed to delete from cloudinary" + (result == true ? "Image Deleted from database" : "Failed to delete from database"));
            }
            return result;
        }

        
    }
}

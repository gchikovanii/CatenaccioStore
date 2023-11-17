using CatenaccioStore.API.Infrastructure.constans;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.API.Controllers
{
    public class ProductImageController : BaseController
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpGet]
        public async Task<IActionResult> GetImages(CancellationToken token)
        {
            return Ok(await _productImageService.GetAll(token));
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPost]
        public async Task<IActionResult> AddImage(CancellationToken token, CreateProductImageDto input)
        {
            return Ok(await _productImageService.AddImage(token, input));
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPost("AddImages")]
        public async Task<IActionResult> AddImages(CancellationToken token, CreateProductImagesDto input)
        {
            return Ok(await _productImageService.AddImages(token, input));
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpDelete]
        public async Task<IActionResult> DeleteImage(CancellationToken token, int imageId)
        {
            return Ok(await _productImageService.DeleteImage(token, imageId));
        }
    }
}

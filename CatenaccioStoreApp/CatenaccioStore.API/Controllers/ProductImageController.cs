using CatenaccioStore.API.Infrastructure.constans;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using CatenaccioStore.Application.Services.Products.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
            try
            {
                return Ok(await _productImageService.GetAll(token));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPost]
        public async Task<IActionResult> AddImage(CancellationToken token, CreateProductImageDto input)
        {
            try
            {
                return Ok(await _productImageService.AddImage(token, input));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPost("AddImages")]
        public async Task<IActionResult> AddImages(CancellationToken token, CreateProductImagesDto input)
        {
            try
            {
                return Ok(await _productImageService.AddImages(token, input));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpDelete]
        public async Task<IActionResult> DeleteImage(CancellationToken token, int imageId)
        {
            try
            {
                return Ok(await _productImageService.DeleteImage(token, imageId));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

using CatenaccioStore.API.Infrastructure.constans;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using static System.Net.Mime.MediaTypeNames;

namespace CatenaccioStore.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpGet]
        public async Task<IActionResult> GetProducts(CancellationToken token)
        {
            try
            {
                return Ok(await _productService.GetAllProducts(token));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.User)]
        [HttpGet("GetFilteredProducts")]
        public async Task<IActionResult> GetFilteredProducts(CancellationToken token, string? brand, string? category)
        {
            try
            {
                return Ok(await _productService.FilteredProducts(token, brand, category)); ;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.User)]
        [HttpGet("GetPaginatedProducts")]
        public async Task<IActionResult> GetPaginatedProducts(CancellationToken token, int pageIndex, int pageSize)
        {
            try
            {
                return Ok(await _productService.GetAllProductsPaginated(token, pageIndex, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.User)]
        [HttpGet("SearchProducts")]
        public async Task<IActionResult> SearchProducts(CancellationToken token, string name)
        {
            try
            {
                return Ok(await _productService.SearchProducts(token, name));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.User)]
        [HttpGet("SortProducts")]
        public async Task<IActionResult> SortProducts(CancellationToken token, string sort)
        {
            try
            {
                return Ok(await _productService.GetAllProductsSortedBy(token, sort));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPost]
        public async Task<IActionResult> AddProduct(CancellationToken token, CreationProductDto product)
        {
            try
            {
                return Ok(await _productService.AddProduct(product, token));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(CancellationToken token, UpdateProductDto product)
        {
            try
            {
                return Ok(await _productService.UpdateProductPrice(product, token));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(CancellationToken token, string productName)
        {
            try
            {
                return Ok(await _productService.DeleteProduct(productName, token));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}

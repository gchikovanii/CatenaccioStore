using CatenaccioStore.API.Infrastructure.constans;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await _productService.GetAllProducts(token));
        }
        [Authorize(Roles = UserType.User)]
        [HttpGet("GetFilteredProducts")]
        public async Task<IActionResult> GetFilteredProducts(CancellationToken token, string? brand, string? category)
        {
            return Ok(await _productService.FilteredProducts(token,brand,category));
        }
        [Authorize(Roles = UserType.User)]
        [HttpGet("GetPaginatedProducts")]
        public async Task<IActionResult> GetPaginatedProducts(CancellationToken token, int pageIndex, int pageSize)
        {
            return Ok(await _productService.GetAllProductsPaginated(token, pageIndex, pageSize));
        }
        [Authorize(Roles = UserType.User)]
        [HttpGet("SearchProducts")]
        public async Task<IActionResult> SearchProducts(CancellationToken token, string name)
        {
            return Ok(await _productService.SearchProducts(token, name));
        }
        [Authorize(Roles = UserType.User)]
        [HttpGet("SortProducts")]
        public async Task<IActionResult> SortProducts(CancellationToken token, string sort)
        {
            return Ok(await _productService.GetAllProductsSortedBy(token, sort));
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPost]
        public async Task<IActionResult> AddProduct(CancellationToken token, CreationProductDto product)
        {
            return Ok(await _productService.AddProduct(product, token));
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(CancellationToken token, UpdateProductDto product)
        {
            return Ok(await _productService.UpdateProductPrice(product, token));
        }
        [Authorize(Roles = UserType.AdminModerator)]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(CancellationToken token, string productName)
        {
            return Ok(await _productService.DeleteProduct(productName, token));
        }

    }
}

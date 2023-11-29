using CatenaccioStore.APP.Data.ViewModels;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using CatenaccioStore.Domain.Entities.Products;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.APP.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductImageService _productImageService;
        public AdminPanelController(IProductService productService, ICategoryService categoryService, IProductImageService productImageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productImageService = productImageService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminPanel()
        {
            var response = new AdminPanelVM();
            return View(response);
        }
        public async Task<IActionResult> AdminPanelCreateProduct()
        {
            CancellationToken token = new CancellationToken();
            var productDto = new GetProductsDto();
            var result = await _categoryService.GetAll(token);
            productDto.Categories = result.Adapt<List<Category>>(); 
            return View(productDto);
        }
        [HttpPost]
        public async Task<IActionResult> AdminPanelCreateProduct(CreationProductDto product, List<IFormFile> images, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _productService.AddProduct(product, token);
            foreach (var image in images)
            {
                var imageDto = new CreateProductImageDto
                {
                    ProductName = product.ProductName,
                    File = image
                };
                await _productImageService.AddImage(token, imageDto);
            }
            return RedirectToAction("AdminPanelProduct");   
        }

        public async Task<IActionResult> AdminPanelProduct(CancellationToken token, int pageIndex = 1, int pageSize = 10)
        {
            var paginatedData = await _productService.GetAllProductsPaginated(token, pageIndex, pageSize);
            var totalCount = await _productService.GetAllProductsCount(token);
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            return View(paginatedData);
        }
        public async Task<IActionResult> AdminPanelProductDetails(int Id, CancellationToken token)
        {
            var productDetials = await _productService.GetById(Id, token);
            if (productDetials == null)
                return View("NotFound");
            return View(productDetials);
        }
    }
}

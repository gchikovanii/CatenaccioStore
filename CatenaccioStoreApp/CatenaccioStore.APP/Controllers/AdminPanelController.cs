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
        public IActionResult AdminPanel()
        {
            var response = new AdminPanelVM();
            return View(response);
        }
        #region Products
        #region Details
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
        #endregion
        #region Create Product
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
        #endregion
        #region UpdateProduct
        public async Task<IActionResult> AdminPanelUpdateProduct(int Id, CancellationToken token)
        {
            var productDetials = await _productService.GetById(Id, token);
            var productDto = new UpdateProductDto();
            var result = await _categoryService.GetAll(token);
            productDto.Categories = result.Adapt<List<Category>>();
            productDto.ShortTitle = productDetials.ShortTitle;
            productDto.Description = productDetials.Description;
            productDto.CategoryName = productDetials.CategoryName;
            productDto.Brand = productDetials.Brand;
            productDto.ProductName = productDetials.ProductName;
            productDto.Price = productDetials.Price;
            productDto.Quantity = productDetials.Quantity;
           
            if (productDetials == null)
                return View("NotFound");
            return View(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> AdminPanelUpdateProduct(UpdateProductDto product, CancellationToken token)
        {
           
            await _productService.UpdateProductPrice(product, token);
            return RedirectToAction("AdminPanelProduct");
        }
        #endregion
        #region Delete
        [HttpPost]
        public async Task<IActionResult> AdminPanelDeleteProduct(int Id, CancellationToken token)
        {
            var productDetials = await _productService.GetById(Id, token);
            if (productDetials == null)
                return View("NotFound");
            await _productService.DeleteProduct(productDetials.ProductName, token);
            return RedirectToAction("AdminPanelProduct");
        }

        #endregion
        #endregion
        #region Categories
        #region Create Product
        public IActionResult AdminPanelCreateCategory()
        {
            var categoryDto = new CreateCategoryDto();
            return View(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> AdminPanelCreateCategory(CreateCategoryDto category, List<IFormFile> images, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            await _categoryService.AddCategory(token, category);
            return RedirectToAction("AdminPanelProduct");
        }
        #endregion


        #endregion
    }
}

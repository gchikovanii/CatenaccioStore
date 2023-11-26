using CatenaccioStore.APP.Data.ViewModels;
using CatenaccioStore.APP.Models;
using CatenaccioStore.APP.Views.Product;
using CatenaccioStore.Application.Services.Products.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.APP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService  _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
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
        public async Task<IActionResult> Search(CancellationToken token,string searchString, int pageIndex = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var products = await _productService.SearchProducts(token, searchString);
                ViewBag.PageIndex = pageIndex; 
                ViewBag.PageSize = pageSize;   
                ViewBag.TotalCount = products.Count; 
                return View("AdminPanelProduct", products);
            }
            var paginatedData = await _productService.GetAllProductsPaginated(token, pageIndex, pageSize);
            var totalCount = await _productService.GetAllProductsCount(token);
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            return View("AdminPanelProduct", paginatedData);
        }

        public IActionResult ProductDetail()
        {
            var response = new ProductDetailVM();
            return View(response);
        }
        public IActionResult Offers()
        {
            var response = new OffersVM();
            return View(response);
        }
        public IActionResult Products()
        {
            var response = new ProductVM();
            return View(response);
        }
    }
}

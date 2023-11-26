using CatenaccioStore.APP.Data.ViewModels;
using CatenaccioStore.APP.Views.Product;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Domain.Entities.Products;
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

        public async Task<IActionResult> Index(CancellationToken token)
        {
            var data = await _productService.GetAllProducts(token);
            return View();
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

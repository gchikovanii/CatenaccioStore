using CatenaccioStore.APP.Data.ViewModels;
using CatenaccioStore.APP.Views.Product;
using CatenaccioStore.Application.Services.Products.Abstraction;
using CatenaccioStore.Application.Services.Products.DTOs;
using CatenaccioStore.Domain.Entities.Products;
using Mapster;
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
        public async Task<IActionResult> AdminPanelProduct(CancellationToken token)
        {
            var products = await _productService.GetAllProducts(token);
            return View(products);
        }
        public async Task<IActionResult> Search(string searchString,CancellationToken token)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var products = await _productService.SearchProducts(token, searchString);
                return View("AdminPanelProduct",products);
            }
            var all = await _productService.GetAllProducts(token);
            return View("AdminPanelProduct", all);
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

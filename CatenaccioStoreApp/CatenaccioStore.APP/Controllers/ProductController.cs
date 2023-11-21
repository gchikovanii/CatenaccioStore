using CatenaccioStore.APP.Data.ViewModels;
using CatenaccioStore.APP.Views.Product;
using CatenaccioStore.Domain.Entities.Products;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.APP.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {
        }

        public IActionResult Index()
        {
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

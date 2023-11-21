using CatenaccioStore.APP.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.APP.Controllers
{
    public class AboutController : Controller
    {
        public AboutController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var response = new AboutVM();
            return View(response);
        }
    }
}

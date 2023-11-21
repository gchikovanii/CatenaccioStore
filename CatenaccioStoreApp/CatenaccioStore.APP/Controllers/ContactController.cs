using CatenaccioStore.APP.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.APP.Controllers
{
    public class ContactController : Controller
    {
        public ContactController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            var response = new ContactVM();
            return View(response);
        }
    }
}

using CatenaccioStore.APP.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.APP.Controllers
{
    public class AdminPanelController : Controller
    {
        public AdminPanelController()
        {
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
    }
}

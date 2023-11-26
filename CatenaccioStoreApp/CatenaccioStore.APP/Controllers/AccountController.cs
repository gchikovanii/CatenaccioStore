using CatenaccioStore.APP.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CatenaccioStore.APP.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }
        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }
    }
}

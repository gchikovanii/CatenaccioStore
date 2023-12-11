using CatenaccioStore.APP.Data.ViewModels;
using CatenaccioStore.Application.Services.Accounts.Abstraction;
using CatenaccioStore.Application.Services.Accounts.DTOs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CatenaccioStore.APP.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginVM login)
        //{
        //    if(!ModelState.IsValid)
        //        return View(login);
        //    var accountExists = await _accountService.GetUserByEmail(login.Email);
        //    if (accountExists != null)
        //    {
        //        var check = await _accountService.LogIn(login.Adapt<LoginDto>());
        //        if(check.IsNullOrEmpty())
        //        {
        //            TempData["Error"] = "Wrong Credentials! Email or Password are Incorrect";
        //            return View(login);
        //        }
        //        return RedirectToAction("Products","Product");
        //    }
        //    TempData["Error"] = "Wrong Credentials! Email or Password are Incorrect";
        //    return View(login);
        //}


        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }
    }
}
